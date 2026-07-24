using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class Tlblaboratory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Disc { get; set; }

    public DateTime DateTime { get; set; }

    public int LabTypeid { get; set; }

    public virtual TlbLabType LabType { get; set; } = null!;

    public virtual ICollection<TlbLabOrder> TlbLabOrders { get; set; } = new List<TlbLabOrder>();
}
