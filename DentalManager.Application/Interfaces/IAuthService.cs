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
        Task<LoginResponseDto> LoginAsync(LoginDto dto);
        Task ChangePasswordAsync(string userId, string oldPassword, string newPassword);
        Task SendPasswordResetCodeAsync(string phoneNumber);
        Task ResetPasswordAsync(string phoneNumber, string code, string newPassword);

    }
}
