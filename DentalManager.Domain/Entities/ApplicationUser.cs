using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class ApplicationUser : IdentityUser
{
    // ========== فیلدهای سفارشی ==========
    public DateTime? LatestActivity { get; set; }
    public DateTime? PasswordChangeDate { get; set; }
    public bool? IsActive { get; set; }
    public long? EmpIdCode { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? CodeMelli { get; set; }
    public bool Gender { get; set; }
    public string? Photo { get; set; }
    public DateTime? PhotoUploadDate { get; set; }
    public bool VerifiedPhone { get; set; }
    public DateTime RegisterDate { get; set; }
    public string? Address { get; set; }
    public string? AddressHome { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool SendSms { get; set; }
    public int? OfficeId { get; set; }
    public string? Reagent { get; set; }
    public byte? Background { get; set; }
    public string? University { get; set; }
    public string? Education { get; set; }

    // ========== رابطه‌ها ==========
    public ICollection<TlbRefreshToken> RefreshTokens { get; set; } = new List<TlbRefreshToken>();
    public ICollection<TlbLoginLog> LoginLogs { get; set; } = new List<TlbLoginLog>();

    // ========== پرسنل ==========
    public virtual Doctor? Doctor { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual ICollection<UserShift> Shifts { get; set; } = new List<UserShift>();
    public virtual ICollection<UserAbsence> Absences { get; set; } = new List<UserAbsence>();
    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
}