using DentalManager.Application.Interfaces;
using DentalManager.Core.Services;


namespace DentalManager.API.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // ========== سرویس‌های Core ==========
        services.AddHostedService<DatabaseWarmupService>();
        services.AddScoped<IAuthService, AuthService>();

        // ========== Repository ها ==========


        return services;
    }
}