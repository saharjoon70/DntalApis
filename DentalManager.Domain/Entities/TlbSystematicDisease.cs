using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbSystematicDisease
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Discription { get; set; }

    public string? Considerations { get; set; }

    public DateTime CreateDateTime { get; set; }

    public virtual ICollection<TlbPatientsFolder> Patients { get; set; } = new List<TlbPatientsFolder>();
}
