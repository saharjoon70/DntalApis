using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbTreatmentDrug
{
    public long Id { get; set; }

    public string? Directions { get; set; }

    public string? Discp { get; set; }

    public long FolderId { get; set; }

    public DateTime RegisterDate { get; set; }

    public int DrugId { get; set; }

    public virtual TlbDrug Drug { get; set; } = null!;

    public virtual TlbPatientsFolder Folder { get; set; } = null!;
}
