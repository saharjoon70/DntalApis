using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbVTreatmentItem
{
    public long Id { get; set; }

    public long VTreatServiceId { get; set; }

    public short TeethId { get; set; }

    public double Cost { get; set; }

    public string? Discription { get; set; }

    public virtual TlbVTreatmentService VTreatService { get; set; } = null!;
}
