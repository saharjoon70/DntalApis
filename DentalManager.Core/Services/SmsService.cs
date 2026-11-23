using DentalManager.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace DentalManager.Infrastructure.ExternalServices;

public class SmsService : ISmsService
{
    private readonly ILogger<SmsService> _logger;

    public SmsService(ILogger<SmsService> logger) => _logger = logger;

    public Task<bool> SendAsync(string phoneNumber, string message, CancellationToken ct = default)
    {
        // TODO: بعداً با سرویس واقعی (Kavenegar / ملی‌پیامک / ...) جایگزین کن
        _logger.LogInformation("📱 [MOCK SMS] → {Phone}\n{Message}", phoneNumber, message);
        return Task.FromResult(true);
    }
}