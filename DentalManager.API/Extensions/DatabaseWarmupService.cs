using DentalManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DentalManager.API.Extensions
{
    public sealed class DatabaseWarmupService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<DatabaseWarmupService> _logger;

        public DatabaseWarmupService(
            IServiceScopeFactory scopeFactory,
            ILogger<DatabaseWarmupService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                await using var scope = _scopeFactory.CreateAsyncScope();

                var db = scope.ServiceProvider.GetRequiredService<DentalContext>();

                var canConnect = await db.Database.CanConnectAsync(cancellationToken);

                if (canConnect)
                {
                    // یک Query بسیار سبک برای آماده شدن EF Core و SqlClient
                    await db.Database.ExecuteSqlRawAsync(
                        "SELECT 1",
                        cancellationToken);

                    _logger.LogInformation("Database warm-up completed successfully.");
                }
                else
                {
                    _logger.LogWarning("Database warm-up failed: cannot connect to SQL Server.");
                }
            }
            catch (Exception ex)
            {
                // بهتر است API فقط به خاطر warm-up متوقف نشود.
                _logger.LogWarning(ex, "Database warm-up failed.");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}


