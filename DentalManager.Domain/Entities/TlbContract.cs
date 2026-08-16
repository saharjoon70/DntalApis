using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbContract
{
    public int ContractId { get; set; }

    public string PersonId { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public decimal? BaseSalary { get; set; }

    public string? PayType { get; set; }

    public decimal? HourlyRate { get; set; }

    public decimal? PercentRate { get; set; }

    public int? Hours { get; set; }

    public short LeaveDays { get; set; }

    public int ContractDuration { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? TerminationText { get; set; }

    public string? ConfidentialityText { get; set; }

    public string? DisputeText { get; set; }

    public string? OtherText { get; set; }

    public string? LetterNumber { get; set; }

    public string? Discription { get; set; }

    public byte[]? EmployeeSignature { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<EmployeeBenefit> EmployeeBenefits { get; set; } = new List<EmployeeBenefit>();

    public virtual ApplicationUser Person { get; set; } = null!;
}
