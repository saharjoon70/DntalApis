using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbVTreatmentService
{
    public long Id { get; set; }

    public long ReserveId { get; set; }

    public int ServicesId { get; set; }

    public short AgeGroup { get; set; }

    public double InsuranceCost { get; set; }

    public virtual TlbReserf Reserve { get; set; } = null!;

    public virtual TlbService Services { get; set; } = null!;

    public virtual ICollection<TlbVTreatmentItem> TlbVTreatmentItems { get; set; } = new List<TlbVTreatmentItem>();
}
