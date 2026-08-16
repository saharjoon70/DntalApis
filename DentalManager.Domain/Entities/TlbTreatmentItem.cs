using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbTreatmentItem
{
    public long Id { get; set; }

    public long TServiceId { get; set; }

    public short TeethId { get; set; }

    public virtual TlbTreatmentService TService { get; set; } = null!;
}
