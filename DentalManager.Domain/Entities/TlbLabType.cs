using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbLabType
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Tlblaboratory> Tlblaboratories { get; set; } = new List<Tlblaboratory>();
}
