using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbLabServiceOrder
{
    public int Id { get; set; }

    public int ServiceLabId { get; set; }

    public string? ServiceDiscription { get; set; }

    public long OrderId { get; set; }

    public virtual TlbLabOrder Order { get; set; } = null!;

    public virtual TlbLabService ServiceLab { get; set; } = null!;

    public virtual ICollection<TlbTeethLab> TlbTeethLabs { get; set; } = new List<TlbTeethLab>();
}
