using DentalManager.Application.DTOs.Auth;
using DentalManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DentalManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// ورود به سیستم
    /// </summary>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginDto dto)
    {
        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";
        var userAgent = Request.Headers["User-Agent"].ToString();

        try
        {
            var result = await _authService.LoginAsync(dto, ipAddress, userAgent);

            return Ok(result);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }



    /// <summary>
    /// اطلاعات کاربر فعلی
    /// </summary>
    [HttpGet("me")]
    [Authorize]
    public IActionResult GetCurrentUser()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var username = User.FindFirstValue(ClaimTypes.Name);
        var role = User.FindFirstValue(ClaimTypes.Role);
        var fullName = User.FindFirstValue("FullName");

        return Ok(new
        {
            UserId = userId,
            Username = username,
            Role = role,
            FullName = fullName
        });
    }

    /// <summary>
    /// تغییر رمز عبور
    /// </summary>
    [HttpPost("change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _authService.ChangePasswordAsync(userId!, dto.OldPassword, dto.NewPassword);
            return Ok(new { message = "رمز عبور با موفقیت تغییر کرد" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// فراموشی رمز عبور - ارسال کد به موبایل
    /// </summary>
    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
    {
        try
        {
            await _authService.SendPasswordResetCodeAsync(dto.PhoneNumber);
            return Ok(new { message = "کد تأیید ارسال شد" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// بازنشانی رمز عبور با کد
    /// </summary>
    [HttpPost("reset-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
    {
        try
        {
            await _authService.ResetPasswordAsync(dto.PhoneNumber, dto.Code, dto.NewPassword);
            return Ok(new { message = "رمز عبور با موفقیت بازنشانی شد" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _authService.RevokeRefreshTokenAsync(userId!);
        return Ok(new { message = "با موفقیت خارج شدید" });
    }
    [HttpPost("refresh")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponseDto>> Refresh(RefreshTokenDto dto)
    {
        try
        {
            var result = await _authService.RefreshTokenAsync(dto.AccessToken, dto.RefreshToken); // ← اینجا
            return Ok(result);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }


}