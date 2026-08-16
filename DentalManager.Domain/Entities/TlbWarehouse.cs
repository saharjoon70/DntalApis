using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbWarehouse
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Disc { get; set; }

    public DateTime RegisterDateTime { get; set; }

    public virtual ICollection<TlbStock> TlbStocks { get; set; } = new List<TlbStock>();
}
