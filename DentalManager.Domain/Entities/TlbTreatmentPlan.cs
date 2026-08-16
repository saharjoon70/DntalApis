using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbTreatmentPlan
{
    public long Id { get; set; }

    public long FolderId { get; set; }

    public string? Title { get; set; }

    public DateTime CreateDateTime { get; set; }

    public string? Discription { get; set; }

    public virtual TlbPatientsFolder Folder { get; set; } = null!;

    public virtual ICollection<TlbReserf> TlbReserves { get; set; } = new List<TlbReserf>();

    public virtual ICollection<TlbTreatmentService> TlbTreatmentServices { get; set; } = new List<TlbTreatmentService>();
}
