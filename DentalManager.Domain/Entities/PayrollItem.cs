using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class PayrollItem
{
    public long Id { get; set; }

    public int PayrollId { get; set; }

    public int ItemTypeId { get; set; }

    public decimal Amount { get; set; }

    public long? PayrollId1 { get; set; }

    public virtual PayrollItemType ItemType { get; set; } = null!;

    public virtual Payroll? PayrollId1Navigation { get; set; }
}
