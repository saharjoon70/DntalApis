using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DentalManager.Application.DTOs.Auth;
using DentalManager.Application.Interfaces;
using DentalManager.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DentalManager.Core.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.Username);

        if (user == null)
            throw new UnauthorizedAccessException("نام کاربری یا رمز عبور اشتباه است");

        //if (!user.IsActive)
        //    throw new UnauthorizedAccessException("این حساب کاربری غیرفعال شده است");

        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, true);

        if (result.IsLockedOut)
            throw new UnauthorizedAccessException("حساب کاربری به دلیل تلاش‌های ناموفق قفل شده است");

        if (!result.Succeeded)
            throw new UnauthorizedAccessException("نام کاربری یا رمز عبور اشتباه است");

        var roles = await _userManager.GetRolesAsync(user);
        var role = roles.FirstOrDefault() ?? "User";
        var token = await GenerateJwtToken(user, role);

        return new LoginResponseDto
        {
            Token = token,
            FullName = user.FirstName + ' ' + user.LastName,
            UserId = user.Id ?? "",
            OfficeCode = user.OfficeId ?? 0,
            Role = role,
            ExpiresAt = DateTime.UtcNow.AddHours(24)
        };
    }

   
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
    }

    public async Task SendPasswordResetCodeAsync(string phoneNumber)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        if (user == null)
            throw new Exception("کاربری با این شماره موبایل یافت نشد");

        // تولید کد تصادفی ۴ رقمی
        var random = new Random();
        var code = random.Next(1000, 9999).ToString();

        // ذخیره کد (می‌تونی توی دیتابیس یا Redis ذخیره کنی)
        // اینجا ساده نوشتم، توی واقعیت باید ذخیره بشه
        // await _smsService.SendCodeAsync(phoneNumber, code);
    }

    public async Task ResetPasswordAsync(string phoneNumber, string code, string newPassword)
    {
        // اینجا باید کد رو چک کنی
        // if (code != savedCode) throw new Exception("کد نامعتبر");

        var user = _userManager.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        if (user == null)
            throw new Exception("کاربر یافت نشد");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"خطا در بازنشانی رمز عبور: {errors}");
        }
    }

    private async Task<string> GenerateJwtToken(ApplicationUser user, string role)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.FirstName +" "+ user.LastName),
            new Claim(ClaimTypes.Role, role),
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(24),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}