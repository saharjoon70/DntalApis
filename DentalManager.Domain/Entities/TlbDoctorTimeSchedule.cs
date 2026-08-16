using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbDoctorTimeSchedule
{
    public int Id { get; set; }

    public long DoctorId { get; set; }

    public short Day { get; set; }

    public virtual TlbDoctor Doctor { get; set; } = null!;

    public virtual ICollection<TlbTiming> TlbTimings { get; set; } = new List<TlbTiming>();
}
