using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class EmployeeBenefit
{
    public int Id { get; set; }

    public int ContractId { get; set; }

    public int PayrollItemTypeId { get; set; }

    public decimal? CustomAmount { get; set; }

    public bool IsEnabled { get; set; }

    public virtual TlbContract Contract { get; set; } = null!;

    public virtual PayrollItemType PayrollItemType { get; set; } = null!;
}
