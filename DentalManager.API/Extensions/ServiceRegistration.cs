using DentalManager.Application.Interfaces;
using DentalManager.Core.Services;
using DentalManager.Infrastructure.ExternalServices;


namespace DentalManager.API.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // ========== سرویس‌های Core ==========
        services.AddHostedService<DatabaseWarmupService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IStaffService, StaffService>();
        services.AddScoped<IContractService, ContractService>();
        services.AddSingleton<ISmsService, SmsService>();
        // ========== Repository ها ==========


        return services;
    }
}