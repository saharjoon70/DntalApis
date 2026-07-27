using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbOfficeAdmin
{
    public int AdminKey { get; set; }

    public string? UserId { get; set; }

    public bool SendSmsnewNotification { get; set; }

    public DateTime RegisterDate { get; set; }

    public virtual ApplicationUser? User { get; set; }
}
