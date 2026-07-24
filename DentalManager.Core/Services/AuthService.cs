using DentalManager.Application.DTOs.Auth;
using DentalManager.Application.Interfaces;
namespace DentalManager.Core.Services
{
    public class AuthService : IAuthService
    {
        public Task<LoginResponseDto> LoginAsync(LoginDto dto)
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(RegisterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
