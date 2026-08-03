using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DentalManager.Application.DTOs.Auth;
using DentalManager.Application.Interfaces;
using DentalManager.Domain.Entities;
using DentalManager.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace DentalManager.Core.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly DentalContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMemoryCache _cache;
    private readonly ILogger<AuthService> _logger;

    private const int CaptchaThreshold = 5;
    private const int CaptchaWindowMinutes = 15;
    private const int AccessTokenMinutesDefault = 15;
    private const int AccessTokenMinutesRememberMe = 120;
    private const int RefreshTokenDaysDefault = 7;
    private const int RefreshTokenDaysRememberMe = 30;

    public AuthService(
        ILogger<AuthService> logger,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration,
        DentalContext context,
        IHttpContextAccessor httpContextAccessor,
        IMemoryCache cache)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _cache = cache;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto dto, string ipAddress, string userAgent)
    {
        var sw = Stopwatch.StartNew();

        var user = await _userManager.FindByNameAsync(dto.Username);
      

        if (user == null)
        {
            await LogLogin(null, ipAddress, userAgent, false, "کاربر یافت نشد");
            throw new UnauthorizedAccessException("نام کاربری یا رمز عبور اشتباه است");
        }

        if (await RequiresCaptcha(user.Id))
        {
            if (string.IsNullOrEmpty(dto.CaptchaId) || !ValidateCaptcha(dto.CaptchaId, dto.CaptchaCode))
            {
                var newCaptchaId = GenerateCaptcha();
                return new LoginResponseDto
                {
                    RequiresCaptcha = true,
                    CaptchaId = newCaptchaId,
                    CaptchaCode = GetCaptchaCode(newCaptchaId)
                };
            }
        }

     
        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure: true);
      

        if (result.IsLockedOut)
        {
            await LogLogin(user.Id, ipAddress, userAgent, false, "حساب قفل شده");
            throw new UnauthorizedAccessException("حساب کاربری به دلیل تلاش‌های ناموفق قفل شده است");
        }

        if (!result.Succeeded)
        {
            await LogLogin(user.Id, ipAddress, userAgent, false, "رمز عبور اشتباه");
            throw new UnauthorizedAccessException("نام کاربری یا رمز عبور اشتباه است");
        }

   
        await LogLogin(user.Id, ipAddress, userAgent, true, null);
     

    
        var roles = await _userManager.GetRolesAsync(user);
       

        var role = roles.FirstOrDefault() ?? "User";
        var accessToken = GenerateAccessToken(user, role, dto.RememberMe);

      
        var (refreshToken, refreshExpiresAt) = await GenerateRefreshTokenAsync(
            user.Id, dto.RememberMe, ipAddress, userAgent);
        sw.Stop();
        _logger.LogInformation("All Time: {Elapsed} ms", sw.ElapsedMilliseconds);

        return new LoginResponseDto
        {
            AccessToken = accessToken.Token,
            RefreshToken = refreshToken,
            FullName = FormatFullName(user),
            Role = role,
            AccessTokenExpiresAt = accessToken.ExpiresAt,
            RefreshTokenExpiresAt = refreshExpiresAt
        };
    }

    public async Task<LoginResponseDto> RefreshTokenAsync(string accessToken, string refreshToken)
    {
        var principal = GetPrincipalFromExpiredToken(accessToken);
        if (principal == null)
            throw new UnauthorizedAccessException("Access Token نامعتبر است");

        var userIdFromAccess = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userIdFromAccess))
            throw new UnauthorizedAccessException("Access Token نامعتبر است");

        var storedToken = await _context.TlbRefreshTokens
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Token == refreshToken && !r.IsRevoked);

        if (storedToken == null || storedToken.ExpiresAt < DateTime.UtcNow)
            throw new UnauthorizedAccessException("Refresh Token نامعتبر است");

        if (storedToken.UserId != userIdFromAccess)
            throw new UnauthorizedAccessException("Refresh Token نامعتبر است");

        var user = storedToken.User;
        var roles = await _userManager.GetRolesAsync(user);
        var role = roles.FirstOrDefault() ?? "User";

        var newRefreshTokenString = GenerateRefreshTokenString();
        storedToken.IsRevoked = true;
        storedToken.ReplacedByToken = newRefreshTokenString;

        var refreshExpire = storedToken.RememberMe
            ? DateTime.UtcNow.AddDays(RefreshTokenDaysRememberMe)
            : DateTime.UtcNow.AddDays(RefreshTokenDaysDefault);

        var newAccessToken = GenerateAccessToken(user, role, storedToken.RememberMe);

        _context.TlbRefreshTokens.Add(new TlbRefreshToken
        {
            UserId = user.Id,
            Token = newRefreshTokenString,
            ExpiresAt = refreshExpire,
            CreatedAt = DateTime.UtcNow,
            RememberMe = storedToken.RememberMe
        });

        await _context.SaveChangesAsync();

        return new LoginResponseDto
        {
            AccessToken = newAccessToken.Token,
            RefreshToken = newRefreshTokenString,
            FullName = FormatFullName(user),
            Role = role,
            AccessTokenExpiresAt = newAccessToken.ExpiresAt,
            RefreshTokenExpiresAt = refreshExpire
        };
    }

    public async Task RevokeRefreshTokenAsync(string userId)
    {
        var tokens = await _context.TlbRefreshTokens
            .Where(r => r.UserId == userId && !r.IsRevoked)
            .ToListAsync();

        foreach (var token in tokens)
            token.IsRevoked = true;

        await _context.SaveChangesAsync();
    }

    public string GenerateCaptcha()
    {
        var captchaId = Guid.NewGuid().ToString("N")[..8];
        var code = RandomNumberGenerator.GetInt32(1000, 10000).ToString();
        _cache.Set($"captcha_{captchaId}", code, TimeSpan.FromMinutes(5));
        return captchaId;
    }

    public string GetCaptchaCode(string captchaId)
    {
        return _cache.TryGetValue($"captcha_{captchaId}", out string? code) ? code ?? "" : "";
    }

    private async Task<bool> RequiresCaptcha(string userId)
    {
        var windowStart = DateTime.UtcNow.AddMinutes(-CaptchaWindowMinutes);
        var failedAttempts = await _context.TlbLoginLogs
            .CountAsync(l => l.UserId == userId && !l.IsSuccess && l.Timestamp >= windowStart);

        return failedAttempts >= CaptchaThreshold;
    }

    private bool ValidateCaptcha(string? captchaId, string? captchaCode)
    {
        if (string.IsNullOrWhiteSpace(captchaId) || string.IsNullOrWhiteSpace(captchaCode))
            return false;

        var key = $"captcha_{captchaId}";
        if (!_cache.TryGetValue(key, out string? storedCode))
            return false;

        _cache.Remove(key);
        return string.Equals(storedCode, captchaCode.Trim(), StringComparison.Ordinal);
    }

    private (string Token, DateTime ExpiresAt) GenerateAccessToken(ApplicationUser user, string role, bool rememberMe)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            //new Claim(ClaimTypes.Name, user.UserName ?? ""),
            new Claim(ClaimTypes.Role, role),
            new Claim("FullName", FormatFullName(user))
        };

        var expireMinutes = rememberMe ? AccessTokenMinutesRememberMe : AccessTokenMinutesDefault;
        var expiresAt = DateTime.UtcNow.AddMinutes(expireMinutes);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expiresAt,
            signingCredentials: credentials);

        return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience = _configuration["Jwt:Audience"],
            ValidateIssuer = true,
            ValidIssuer = _configuration["Jwt:Issuer"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)),
            ValidateLifetime = false // فقط برای refresh؛ توکن منقضی مجاز است
        };

        try
        {
            var handler = new JwtSecurityTokenHandler();
            return handler.ValidateToken(token, tokenValidationParameters, out _);
        }
        catch
        {
            return null;
        }
    }

    private async Task<(string Token, DateTime ExpiresAt)> GenerateRefreshTokenAsync(
        string userId, bool rememberMe, string ipAddress, string userAgent)
    {
        var token = GenerateRefreshTokenString();
        var expiresAt = rememberMe
            ? DateTime.UtcNow.AddDays(RefreshTokenDaysRememberMe)
            : DateTime.UtcNow.AddDays(RefreshTokenDaysDefault);

        _context.TlbRefreshTokens.Add(new TlbRefreshToken
        {
            UserId = userId,
            Token = token,
            ExpiresAt = expiresAt,
            CreatedAt = DateTime.UtcNow,
            RememberMe = rememberMe
        });

        await _context.SaveChangesAsync();
        return (token, expiresAt);
    }

    private static string GenerateRefreshTokenString()
    {
        var randomBytes = new byte[64];
        RandomNumberGenerator.Fill(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }

    private async Task LogLogin(string? userId, string ipAddress, string userAgent, bool isSuccess, string? failReason)
    {
        if (userId == null)
            return;

        _context.TlbLoginLogs.Add(new TlbLoginLog
        {
            UserId = userId,
            IpAddress = ipAddress,
            UserAgent = userAgent,
            IsSuccess = isSuccess,
            FailReason = failReason,
            Timestamp = DateTime.UtcNow
        });

        await _context.SaveChangesAsync();
    }

    private static string FormatFullName(ApplicationUser user) =>
        $"{user.FirstName ?? ""} {user.LastName ?? ""}".Trim();

    public async Task ChangePasswordAsync(string userId, string oldPassword, string newPassword)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            throw new Exception("کاربر یافت نشد");

        var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"خطا در تغییر رمز عبور: {errors}");
        }

        await RevokeRefreshTokenAsync(userId);
    }

    public async Task SendPasswordResetCodeAsync(string phoneNumber)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        if (user == null)
            throw new Exception("کاربری با این شماره موبایل یافت نشد");

        var code = RandomNumberGenerator.GetInt32(1000, 10000).ToString();
        var cacheKey = $"pwd_reset_{phoneNumber}";
        _cache.Set(cacheKey, code, TimeSpan.FromMinutes(5));

        // TODO: ارسال SMS با سرویس پیامک
        _logger.LogInformation("Password reset code generated for {Phone}", phoneNumber);
        await Task.CompletedTask;
    }

    public async Task ResetPasswordAsync(string phoneNumber, string code, string newPassword)
    {
        var cacheKey = $"pwd_reset_{phoneNumber}";
        if (!_cache.TryGetValue(cacheKey, out string? storedCode) ||
            !string.Equals(storedCode, code?.Trim(), StringComparison.Ordinal))
            throw new Exception("کد تأیید نامعتبر یا منقضی شده است");

        _cache.Remove(cacheKey);

        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        if (user == null)
            throw new Exception("کاربر یافت نشد");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"خطا در بازنشانی رمز عبور: {errors}");
        }

        await RevokeRefreshTokenAsync(user.Id);
    }
}
