using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbLabService
{
    public int Id { get; set; }

    public string? ServiceLab { get; set; }

    public virtual ICollection<TlbLabServiceOrder> TlbLabServiceOrders { get; set; } = new List<TlbLabServiceOrder>();
}
