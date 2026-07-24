using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class PayrollItemType
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool IsDeduction { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<EmployeeBenefit> EmployeeBenefits { get; set; } = new List<EmployeeBenefit>();

    public virtual ICollection<PayrollItem> PayrollItems { get; set; } = new List<PayrollItem>();

    public virtual ICollection<PayrollSetting> PayrollSettings { get; set; } = new List<PayrollSetting>();
}
