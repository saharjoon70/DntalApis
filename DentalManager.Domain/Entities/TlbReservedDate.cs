using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbReservedDate
{
    public int Id { get; set; }

    public int FkTimingId { get; set; }

    public DateTime ReserveDate { get; set; }

    public virtual TlbTiming FkTiming { get; set; } = null!;
}
