using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class ApplicationRoleClaim
{
    public int Id { get; set; }

    public string RoleId { get; set; } = null!;

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual ApplicationRole Role { get; set; } = null!;
}
