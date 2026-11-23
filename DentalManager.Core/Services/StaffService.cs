using DentalManager.Application.DTOs.Staff;
using DentalManager.Application.Interfaces;
using DentalManager.Domain.Entities;
using DentalManager.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DentalManager.Core.Services;

public class StaffService : IStaffService
{
    private readonly DentalContext _ctx;
    private readonly UserManager<ApplicationUser> _userManager;
    private const string DefaultPassword = "Staff@12345";
    private readonly ISmsService _sms;

    public StaffService(DentalContext ctx, UserManager<ApplicationUser> userManager, ISmsService sms)
    {
        _ctx = ctx;
        _userManager = userManager;
        _sms = sms;
    }

    public async Task<StaffListResult> GetListAsync(StaffQueryDto q, CancellationToken ct = default)
    {
        var query = _ctx.AppUsers
            .Include(u => u.Doctor)
            .Include(u => u.Employee)
            .Include(u => u.Contracts)
            .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)   
            .AsNoTracking()
            .AsQueryable();

        // فیلترها
        if (!string.IsNullOrWhiteSpace(q.Search))
        {
            var s = q.Search.Trim();
            query = query.Where(u =>
                (u.FirstName != null && u.FirstName.Contains(s)) ||
                (u.LastName != null && u.LastName.Contains(s)) ||
                (u.Doctor != null && u.Doctor.MedicalCode != null && u.Doctor.MedicalCode.Contains(s)) ||
                (u.Doctor != null && u.Doctor.Specialty != null && u.Doctor.Specialty.Contains(s)) ||
                (u.Employee != null && u.Employee.Position != null && u.Employee.Position.Contains(s)) ||
                (u.PhoneNumber != null && u.PhoneNumber.Contains(s)));
        }

        if (q.Role == "doctor") query = query.Where(u => u.Doctor != null);
        else if (q.Role == "staff") query = query.Where(u => u.Employee != null);

        if (q.ActiveFilter == "active") query = query.Where(u => u.IsActive == true);
        else if (q.ActiveFilter == "inactive") query = query.Where(u => u.IsActive != true);

        if (q.ContractFilter == "has-contract")
            query = query.Where(u => u.Contracts.Any(c => c.Status != "terminated"));
        else if (q.ContractFilter == "no-contract")
            query = query.Where(u => !u.Contracts.Any(c => c.Status != "terminated"));

        var total = await query.CountAsync(ct);

        // KPI ها روی کل query (بدون page)
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var doctorsCount = await query.CountAsync(u => u.Doctor != null && u.IsActive == true, ct);
        var staffCount = await query.CountAsync(u => u.Employee != null && u.IsActive == true, ct);

        var absentToday = await _ctx.UserAbsences
    .CountAsync(a => DateOnly.FromDateTime(a.Date) == today && a.User.IsActive == true, ct);
        var presentToday = Math.Max(0, doctorsCount - absentToday);
        var activeContracts = await _ctx.Contracts
            .CountAsync(c => c.Status != "terminated" && (c.EndDate == null || c.EndDate >= today), ct);

        var users = await query
            .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
            .Skip((q.Page - 1) * q.PageSize)
            .Take(q.PageSize)
            .ToListAsync(ct);

        return new StaffListResult
        {
            Items = users.Select(Map).ToList(),
            Total = total,
            Page = q.Page,
            PageSize = q.PageSize,
            DoctorsCount = doctorsCount,
            StaffCount = staffCount,
            PresentToday = presentToday,
            AbsentToday = absentToday,
            ActiveContracts = activeContracts
        };
    }

    public async Task<StaffDto?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        var user = await _ctx.AppUsers
            .Include(u => u.Doctor)
            .Include(u => u.Employee)
            .Include(u => u.Contracts)
             .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)   // ⭐ اضافه
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id, ct);
        return user == null ? null : Map(user);
    }

    public async Task<StaffDto> CreateDoctorAsync(StaffCreateDoctorDto dto, CancellationToken ct = default)
    {
        try
        {
            var user = await CreateUserBaseAsync(
                dto.FirstName, dto.LastName, dto.Phone, dto.NationalCode,
                dto.BirthDate, dto.Gender, dto.Email, dto.Address, dto.Password, ct);

            var doctor = new Doctor { UserId = user.Id, MedicalCode = dto.MedicalCode, Specialty = dto.Specialty };
            _ctx.Doctors.Add(doctor);
            await _ctx.SaveChangesAsync(ct);

            await _userManager.AddToRoleAsync(user, "Doctor");
            user.Doctor = doctor;
            var staffDto = Map(user);
            staffDto.GeneratedUsername = user.UserName;
            staffDto.GeneratedPassword = user.PhoneNumber;
            await SendCredentialsSmsAsync(user, staffDto, ct);
            return staffDto;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    private async Task SendCredentialsSmsAsync(ApplicationUser user, StaffDto dto, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(user.PhoneNumber))
        {
            dto.SmsSent = false;
            dto.SmsError = "شماره موبایل ثبت نشده";
            return;
        }

        var fullName = $"{user.FirstName} {user.LastName}".Trim();
        var message =
            $"{fullName} عزیز، به سامانه دنتال خوش آمدید.\n" +
            $"نام کاربری: {user.UserName}\n" +
            $"رمز عبور: {user.PhoneNumber}";

        try
        {
            var sent = await _sms.SendAsync(user.PhoneNumber, message, ct);
            dto.SmsSent = sent;
            dto.SmsError = sent ? null : "ارسال پیامک ناموفق بود";
        }
        catch (Exception ex)
        {
            dto.SmsSent = false;
            dto.SmsError = ex.Message;
        }
    }
    public async Task<StaffDto> CreateEmployeeAsync(StaffCreateEmployeeDto dto, CancellationToken ct = default)
    {
        var user = await CreateUserBaseAsync(
            dto.FirstName, dto.LastName, dto.Phone, dto.NationalCode,
            dto.BirthDate, dto.Gender, dto.Email, dto.Address, dto.Password, ct);

        var emp = new Employee { UserId = user.Id, Position = dto.Position };
        _ctx.Employees.Add(emp);
        await _ctx.SaveChangesAsync(ct);

        var role = ResolveRoleForPosition(dto.Position);
        await _userManager.AddToRoleAsync(user, role);
        user.Employee = emp;
        var staffDto = Map(user);
        staffDto.GeneratedUsername = user.UserName;
        staffDto.GeneratedPassword = user.PhoneNumber;
        await SendCredentialsSmsAsync(user, staffDto, ct);
        return staffDto;
    }

    public async Task<StaffDto> UpdateAsync(string id, StaffUpdateDto dto, CancellationToken ct = default)
    {
        var user = await _ctx.AppUsers
            .Include(u => u.Doctor).Include(u => u.Employee).Include(u => u.Contracts)
            .FirstOrDefaultAsync(u => u.Id == id, ct)
            ?? throw new KeyNotFoundException($"User {id} not found");

        if (dto.FirstName != null) user.FirstName = dto.FirstName;
        if (dto.LastName != null) user.LastName = dto.LastName;
        if (dto.NationalCode != null) user.CodeMelli = dto.NationalCode;
        if (dto.BirthDate != null) user.BirthDate = dto.BirthDate;
        if (dto.Gender != null) user.Gender = dto.Gender.Value;
        if (dto.Phone != null) user.PhoneNumber = dto.Phone;
        if (dto.Email != null) user.Email = dto.Email;
        if (dto.Address != null) user.Address = dto.Address;

        if (user.Doctor != null && (dto.MedicalCode != null || dto.Specialty != null))
        {
            if (dto.MedicalCode != null) user.Doctor.MedicalCode = dto.MedicalCode;
            if (dto.Specialty != null) user.Doctor.Specialty = dto.Specialty;
        }
        if (user.Employee != null && dto.Position != null)
            user.Employee.Position = dto.Position;

        await _ctx.SaveChangesAsync(ct);
        return Map(user);
    }

    public async Task<bool> ToggleActiveAsync(string id, CancellationToken ct = default)
    {
        var user = await _ctx.AppUsers.FirstOrDefaultAsync(u => u.Id == id, ct)
            ?? throw new KeyNotFoundException();
        user.IsActive = !(user.IsActive ?? true);
        await _ctx.SaveChangesAsync(ct);
        return user.IsActive.Value;
    }

    public async Task DeleteAsync(string id, CancellationToken ct = default)
    {
        var user = await _ctx.AppUsers.FirstOrDefaultAsync(u => u.Id == id, ct)
            ?? throw new KeyNotFoundException();
        await _ctx.SaveChangesAsync(ct);          // ابتدا حذف links و گرنه FK می‌شکند
        await _userManager.DeleteAsync(user);     // Cascade بقیه را پاک می‌کند
    }

    public async Task<int> BulkDeleteAsync(IEnumerable<string> ids, CancellationToken ct = default)
    {
        var count = 0;
        foreach (var id in ids)
        {
            try { await DeleteAsync(id, ct); count++; }
            catch { /* ignore individual failure */ }
        }
        return count;
    }

    // ---------- Helpers ----------
    private async Task<ApplicationUser> CreateUserBaseAsync(
        string firstName, string lastName, string phone, string? nationalCode,
        DateTime? birthDate, bool gender, string? email, string? address,
        string? password, CancellationToken ct)
    {
        var userName = phone;
        if (await _userManager.FindByNameAsync(userName) != null)
            throw new InvalidOperationException($"Username '{userName}' already exists");

        var user = new ApplicationUser
        {
            UserName = userName,
            Email = email,
            PhoneNumber = phone,
            FirstName = firstName,
            LastName = lastName,
            CodeMelli = nationalCode,
            BirthDate = birthDate,
            Gender = gender,
            Address = address,
            IsActive = true,
            RegisterDate = DateTime.UtcNow,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, password ?? DefaultPassword);
        if (!result.Succeeded)
            throw new InvalidOperationException(
                "Create user failed: " + string.Join(" | ", result.Errors.Select(e => e.Description)));

        return user;
    }

    private static string ResolveRoleForPosition(string position) => position switch
    {
        "منشی" or "پذیرش" => "Secretary",
        "دستیار" => "Asistant",
        "حسابداری" => "FinancialOfficer",
        _ => "Secretary"
    };

    private static StaffDto Map(ApplicationUser u)
    {
        var activeContracts = u.Contracts.Where(c => c.Status != "terminated").ToList();
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var status = "none";
        if (activeContracts.Any())
        {
            status = activeContracts.Any(c => c.EndDate == null || c.EndDate >= today)
                ? "active" : "expired";
        }

        int? age = null;
        if (u.BirthDate.HasValue)
        {
            var todayDt = DateTime.UtcNow.Date;
            age = todayDt.Year - u.BirthDate.Value.Year;
            if (u.BirthDate.Value.Date > todayDt.AddYears(-age.Value)) age--;
        }

        // ⭐ نقش اصلی را از AspNetUserRoles بگیر (اولین نقش)
        var primaryRole = u.UserRoles.FirstOrDefault()?.Role;

        return new StaffDto
        {
            Id = u.Id,
            FullName = $"{u.FirstName} {u.LastName}".Trim(),

            // role فنی (برای فیلتر doctor/staff)
            Role = u.Doctor != null ? "doctor" : "staff",

            // نام و نام فارسی نقش از AspNetRoles
            RoleName = primaryRole?.Name,
            RoleFaName = primaryRole?.FaName,

            MedicalCode = u.Doctor?.MedicalCode,
            Specialty = u.Doctor?.Specialty,
            Position = u.Employee?.Position,
            NationalCode = u.CodeMelli,
            BirthDate = u.BirthDate,
            Age = age,
            Gender = u.Gender ? "male" : "female",
            Phone = u.PhoneNumber,
            Email = u.Email,
            Address = u.Address,
            Photo = u.Photo,
            Active = u.IsActive ?? true,
            ContractStatus = status,
            ContractCount = u.Contracts.Count,
            CreatedAt = u.RegisterDate
        };
    }
}