using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbTiming
{
    public int Id { get; set; }

    public bool Status { get; set; }

    public string? TimeName { get; set; }

    public int TimeSchTblId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int Slot { get; set; }

    public virtual TlbDoctorTimeSchedule TimeSchTbl { get; set; } = null!;

    public virtual ICollection<TlbReservedDate> TlbReservedDates { get; set; } = new List<TlbReservedDate>();
}
