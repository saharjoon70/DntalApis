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

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration,
        DentalContext context,
        IHttpContextAccessor httpContextAccessor,
        IMemoryCache cache)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _cache = cache;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto dto, string ipAddress, string userAgent)
    {
        var user = await _userManager.FindByNameAsync(dto.Username);

        if (user == null)
        {
            await LogLogin(null, ipAddress, userAgent, false, "کاربر یافت نشد");
            throw new UnauthorizedAccessException("نام کاربری یا رمز عبور اشتباه است");
        }

        // چک کردن نیاز به Captcha
        if (await RequiresCaptcha(user.Id))
        {
            if (string.IsNullOrEmpty(dto.CaptchaId) || !ValidateCaptcha(dto.CaptchaId, dto.CaptchaCode))
            {
                var newCaptchaId = GenerateCaptcha();
                var captchaCode = GetCaptchaCode(newCaptchaId);
                return new LoginResponseDto
                {
                    RequiresCaptcha = true,
                    CaptchaId = newCaptchaId,
                    CaptchaCode = captchaCode
                };
            }
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, true);

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
        var refreshToken = await GenerateRefreshToken(user.Id, dto.RememberMe, ipAddress, userAgent);

        return new LoginResponseDto
        {
            AccessToken = accessToken.Token,
            RefreshToken = refreshToken,
            FullName = user.FirstName ?? "" + " " + user.LastName ?? "",
            Role = role,
            AccessTokenExpiresAt = accessToken.ExpiresAt,
            RefreshTokenExpiresAt = dto.RememberMe ? DateTime.UtcNow.AddDays(30) : DateTime.UtcNow.AddDays(7)
        };
    }

    public async Task<LoginResponseDto> RefreshTokenAsync(string accessToken, string refreshToken)
    {
        var storedToken = await _context.TlbRefreshTokens
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Token == refreshToken && !r.IsRevoked);

        if (storedToken == null || storedToken.ExpiresAt < DateTime.UtcNow)
            throw new UnauthorizedAccessException("Refresh Token نامعتبر است");

        var newRefreshToken = GenerateRefreshTokenString();
        storedToken.IsRevoked = true;
        storedToken.ReplacedByToken = newRefreshToken;

        var user = storedToken.User;
        var roles = await _userManager.GetRolesAsync(user);
        var role = roles.FirstOrDefault() ?? "User";
        var newAccessToken = GenerateAccessToken(user, role, storedToken.RememberMe);

        var refreshExpire = storedToken.RememberMe
            ? DateTime.UtcNow.AddDays(30)
            : DateTime.UtcNow.AddDays(7);

        _context.TlbRefreshTokens.Add(new TlbRefreshToken
        {
            UserId = user.Id,
            Token = newRefreshToken,
            ExpiresAt = refreshExpire,
            CreatedAt = DateTime.UtcNow,
            RememberMe = storedToken.RememberMe
        });

        await _context.SaveChangesAsync();

        return new LoginResponseDto
        {
            AccessToken = newAccessToken.Token,
            RefreshToken = newRefreshToken,
            FullName = user.FirstName ?? "" + " "+ user.LastName?? "",
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
        {
            token.IsRevoked = true;
        }

        await _context.SaveChangesAsync();
    }

    // ========== Captcha ==========

    public string GenerateCaptcha()
    {
        var captchaId = Guid.NewGuid().ToString("N")[..8];
        var code = new Random().Next(1000, 9999).ToString();

        _cache.Set($"captcha_{captchaId}", code, TimeSpan.FromMinutes(5));

        return captchaId; // برگشت ID به Frontend
    }

    public string GetCaptchaCode(string captchaId)
    {
        if (_cache.TryGetValue($"captcha_{captchaId}", out string? code))
            return code ?? "";

        return "";
    }

    private async Task<bool> RequiresCaptcha(string userId)
    {
        var fifteenMinutesAgo = DateTime.UtcNow.AddMinutes(-15);
        var failedAttempts = await _context.TlbLoginLogs
            .CountAsync(l => l.UserId == userId && !l.IsSuccess && l.Timestamp >= fifteenMinutesAgo);

        return failedAttempts >= 5;
    }

    private bool ValidateCaptcha(string? captchaId, string? captchaCode)
    {
        if (string.IsNullOrEmpty(captchaId) || string.IsNullOrEmpty(captchaCode))
            return false;

        if (_cache.TryGetValue($"captcha_{captchaId}", out string? storedCode))
        {
            _cache.Remove($"captcha_{captchaId}"); // یه بار مصرف
            return storedCode == captchaCode;
        }

        return false;
    }

    // ========== Private Methods ==========

    private (string Token, DateTime ExpiresAt) GenerateAccessToken(ApplicationUser user, string role, bool rememberMe)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName ?? ""),
            new Claim(ClaimTypes.Role, role),
            new Claim("FullName", user.FirstName ?? "" + " " + user.LastName?? "")
        };

        var expireHours = rememberMe ? 120 : 15;
        var expiresAt = DateTime.UtcNow.AddMinutes(expireHours);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expiresAt,
            signingCredentials: credentials
        );

        return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
    }

    private async Task<string> GenerateRefreshToken(string userId, bool rememberMe, string ipAddress, string userAgent)
    {
        var token = GenerateRefreshTokenString();

        _context.TlbRefreshTokens.Add(new TlbRefreshToken
        {
            UserId = userId,
            Token = token,
            ExpiresAt = rememberMe ? DateTime.UtcNow.AddDays(30) : DateTime.UtcNow.AddDays(7),
            CreatedAt = DateTime.UtcNow,
            RememberMe = rememberMe
        });

        await _context.SaveChangesAsync();
        return token;
    }

    private string GenerateRefreshTokenString()
    {
        var randomBytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }

    private async Task LogLogin(string? userId, string ipAddress, string userAgent, bool isSuccess, string? failReason)
    {
        if (userId == null) return;
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

    public async Task ChangePasswordAsync(string userId, string oldPassword, string newPassword)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) throw new Exception("کاربر یافت نشد");

        var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"خطا در تغییر رمز عبور: {errors}");
        }

        // باطل کردن همه RefreshToken ها
        await RevokeRefreshTokenAsync(userId);
    }
    public async Task SendPasswordResetCodeAsync(string phoneNumber)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        if (user == null)
            throw new Exception("کاربری با این شماره موبایل یافت نشد");

        var random = new Random();
        var code = random.Next(1000, 9999).ToString();
    }

    public async Task ResetPasswordAsync(string phoneNumber, string code, string newPassword)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        if (user == null) throw new Exception("کاربر یافت نشد");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"خطا در بازنشانی رمز عبور: {errors}");
        }

        // باطل کردن همه RefreshToken ها
        await RevokeRefreshTokenAsync(user.Id);
    }
}