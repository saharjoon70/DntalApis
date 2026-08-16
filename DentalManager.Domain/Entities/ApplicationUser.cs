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



    // ========== رابطه‌های جدید ==========
    public ICollection<TlbRefreshToken> RefreshTokens { get; set; } = new List<TlbRefreshToken>();
    public ICollection<TlbLoginLog> LoginLogs { get; set; } = new List<TlbLoginLog>(); // اسم درست

    // ========== بقیه رابطه‌ها ==========
    public virtual ICollection<BankAccountStaff> BankAccountStaffs { get; set; } = new List<BankAccountStaff>();
    public virtual TlbOfficeBuilding? Office { get; set; }
    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();
    public virtual ICollection<TlbContract> TlbContracts { get; set; } = new List<TlbContract>();
    public virtual TlbDoctor? TlbDoctor { get; set; }
    public virtual ICollection<TlbLeaf> TlbLeaves { get; set; } = new List<TlbLeaf>();
    public virtual TlbOfficeAdmin? TlbOfficeAdmin { get; set; }

   




}