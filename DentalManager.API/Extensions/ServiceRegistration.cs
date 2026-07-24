using DentalManager.Application.Interfaces;
using DentalManager.Core.Services;
using DentalManager.Application.Interfaces;

namespace DentalManager.API.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // ========== سرویس‌های Core ==========

        services.AddScoped<IAuthService, AuthService>();

        // ========== Repository ها ==========


        return services;
    }
}