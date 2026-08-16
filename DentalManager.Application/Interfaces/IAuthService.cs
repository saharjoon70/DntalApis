using DentalManager.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalManager.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponseDto> LoginAsync(LoginDto dto, string ipAddress, string userAgent);
        Task ChangePasswordAsync(string userId, string oldPassword, string newPassword);
        Task SendPasswordResetCodeAsync(string phoneNumber);
        Task ResetPasswordAsync(string phoneNumber, string code, string newPassword);
        public Task RevokeRefreshTokenAsync(string userId);
        public Task<LoginResponseDto> RefreshTokenAsync(string accessToken, string refreshToken);
    }
}
