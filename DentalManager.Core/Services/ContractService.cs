using DentalManager.Application.DTOs.Contracts;
using DentalManager.Application.Interfaces;
using DentalManager.Domain.Entities;
using DentalManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DentalManager.Core.Services;

public class ContractService : IContractService
{
    private readonly DentalContext _ctx;
    private static readonly JsonSerializerOptions JsonOpts = new(JsonSerializerDefaults.Web);

    public ContractService(DentalContext ctx) => _ctx = ctx;

    public async Task<List<ContractDto>> GetByPersonAsync(string personId, CancellationToken ct = default)
    {
        var user = await _ctx.AppUsers.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == personId, ct);
        if (user == null) return new();

        var personName = $"{user.FirstName} {user.LastName}".Trim();

        var contracts = await _ctx.Contracts.AsNoTracking()
            .Where(c => c.UserId == personId)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync(ct);

        return contracts.Select(c => Map(c, personName)).ToList();
    }

    public async Task<ContractDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var c = await _ctx.Contracts.AsNoTracking()
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
        if (c == null) return null;
        return Map(c, $"{c.User.FirstName} {c.User.LastName}".Trim());
    }

    public async Task<ContractDto> CreateAsync(ContractCreateDto dto, CancellationToken ct = default)
    {
        var user = await _ctx.AppUsers.FirstOrDefaultAsync(u => u.Id == dto.PersonId, ct)
            ?? throw new KeyNotFoundException($"Person {dto.PersonId} not found");

        var start = DateOnly.Parse(dto.StartDate);
        DateOnly? end = dto.Duration == "0" || string.IsNullOrEmpty(dto.EndDate)
            ? null
            : DateOnly.Parse(dto.EndDate);

        var contract = new Contract
        {
            UserId = dto.PersonId,
            StartDate = start,
            Duration = dto.Duration,
            EndDate = end,
            ContractType = dto.ContractType,
            JobTitle = dto.JobTitle,
            Duties = dto.Duties,
            PaymentType = dto.PaymentType,
            BaseSalary = dto.BaseSalary,
            Commission = dto.Commission,
            Bonus = dto.Bonus,
            Transport = dto.Transport,
            Overtime = dto.Overtime,
            Insurance = dto.Insurance,
            CardNumber = dto.CardNumber,
            Tax = dto.Tax,
            ClausesJson = JsonSerializer.Serialize(dto.Clauses, JsonOpts),
            Status = "active",
            CreatedAt = DateTime.UtcNow
        };

        _ctx.Contracts.Add(contract);
        await _ctx.SaveChangesAsync(ct);

        return Map(contract, $"{user.FirstName} {user.LastName}".Trim());
    }

    public async Task<ContractDto> UpdateAsync(int id, ContractUpdateDto dto, CancellationToken ct = default)
    {
        var c = await _ctx.Contracts.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new KeyNotFoundException();

        c.StartDate = DateOnly.Parse(dto.StartDate);
        c.Duration = dto.Duration;
        c.EndDate = dto.Duration == "0" || string.IsNullOrEmpty(dto.EndDate) ? null : DateOnly.Parse(dto.EndDate);
        c.ContractType = dto.ContractType;
        c.JobTitle = dto.JobTitle;
        c.Duties = dto.Duties;
        c.PaymentType = dto.PaymentType;
        c.BaseSalary = dto.BaseSalary;
        c.Commission = dto.Commission;
        c.Bonus = dto.Bonus;
        c.Transport = dto.Transport;
        c.Overtime = dto.Overtime;
        c.Insurance = dto.Insurance;
        c.CardNumber = dto.CardNumber;
        c.Tax = dto.Tax;
        c.ClausesJson = JsonSerializer.Serialize(dto.Clauses, JsonOpts);

        await _ctx.SaveChangesAsync(ct);
        return Map(c, $"{c.User.FirstName} {c.User.LastName}".Trim());
    }

    public async Task<ContractDto> TerminateAsync(int id, CancellationToken ct = default)
    {
        var c = await _ctx.Contracts.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new KeyNotFoundException();
        c.Status = "terminated";
        c.TerminatedAt = DateTime.UtcNow;
        await _ctx.SaveChangesAsync(ct);
        return Map(c, $"{c.User.FirstName} {c.User.LastName}".Trim());
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var c = await _ctx.Contracts.FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new KeyNotFoundException();
        _ctx.Contracts.Remove(c);
        await _ctx.SaveChangesAsync(ct);
    }

    private static ContractDto Map(Contract c, string personName)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var status = c.Status;
        if (status != "terminated" && c.EndDate.HasValue && c.EndDate.Value < today)
            status = "expired";

        List<ContractClauseDto> clauses = new();
        if (!string.IsNullOrEmpty(c.ClausesJson))
        {
            try { clauses = JsonSerializer.Deserialize<List<ContractClauseDto>>(c.ClausesJson, JsonOpts) ?? new(); }
            catch { /* ignore */ }
        }

        return new ContractDto
        {
            Id = c.Id,
            PersonId = c.UserId,
            PersonName = personName,
            StartDate = c.StartDate.ToString("yyyy-MM-dd"),
            Duration = c.Duration,
            EndDate = c.EndDate?.ToString("yyyy-MM-dd"),
            ContractType = c.ContractType,
            JobTitle = c.JobTitle,
            Duties = c.Duties,
            PaymentType = c.PaymentType,
            BaseSalary = c.BaseSalary,
            Commission = c.Commission,
            Bonus = c.Bonus,
            Transport = c.Transport,
            Overtime = c.Overtime,
            Insurance = c.Insurance,
            CardNumber = c.CardNumber,
            Tax = c.Tax,
            Clauses = clauses,
            Status = status,
            CreatedAt = c.CreatedAt.ToString("yyyy-MM-dd"),
            TerminatedAt = c.TerminatedAt?.ToString("yyyy-MM-dd")
        };
    }
}