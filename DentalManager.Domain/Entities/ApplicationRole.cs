using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class ApplicationRole : IdentityRole
{
    public string Id { get; set; } = null!;

    public string? FaName { get; set; }

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public virtual ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
}
