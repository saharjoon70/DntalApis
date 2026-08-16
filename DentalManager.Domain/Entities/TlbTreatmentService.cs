using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbTreatmentService
{
    public long TServiceId { get; set; }

    public long TreatmentId { get; set; }

    public int ServicesId { get; set; }

    public short AgeGroup { get; set; }

    public virtual TlbService Services { get; set; } = null!;

    public virtual ICollection<TlbTreatmentItem> TlbTreatmentItems { get; set; } = new List<TlbTreatmentItem>();

    public virtual TlbTreatmentPlan Treatment { get; set; } = null!;
}
