
using DentalManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DentalManager.Infrastructure.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // ۱. ثبت DbContext
        services.AddDbContext<DentalContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));



        return services;
    }
}