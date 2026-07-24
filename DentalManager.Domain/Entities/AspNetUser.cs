using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class AspNetUser
{
    public string Id { get; set; } = null!;

    public DateTime? LatestActivity { get; set; }

    public DateTime? PasswordChangeDate { get; set; }

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

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    public virtual ICollection<BankAccountStaff> BankAccountStaffs { get; set; } = new List<BankAccountStaff>();

    public virtual TlbOfficeBuilding? Office { get; set; }

    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();

    public virtual ICollection<TlbContract> TlbContracts { get; set; } = new List<TlbContract>();

    public virtual TlbDoctor? TlbDoctor { get; set; }

    public virtual ICollection<TlbLeaf> TlbLeaves { get; set; } = new List<TlbLeaf>();

    public virtual TlbOfficeAdmin? TlbOfficeAdmin { get; set; }

    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
