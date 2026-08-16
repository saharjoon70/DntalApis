using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbStockGroup
{
    public int Id { get; set; }

    public string? GroupName { get; set; }

    public string? NormalizeGroupName { get; set; }

    public string? Unit { get; set; }

    public DateTime RegisterDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual ICollection<TlbStock> TlbStocks { get; set; } = new List<TlbStock>();
}
