using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbLeaf
{
    public int Id { get; set; }

    public TimeOnly Output { get; set; }

    public TimeOnly Input { get; set; }

    public DateTime LeaveDateTime { get; set; }

    public string? UserId { get; set; }

    public virtual ApplicationUser? User { get; set; }
}
