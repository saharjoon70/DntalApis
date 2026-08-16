using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;
public partial class PayrollSetting
{
    public int Id { get; set; }

    public int ItemTypeId { get; set; }

    public decimal Value { get; set; }

    public DateTime StartDate { get; set; }

    public virtual PayrollItemType ItemType { get; set; } = null!;
}
