using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class ApplicationRole : IdentityRole
{

    public string? FaName { get; set; }

    public string? Name { get; set; }


    public ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();

}
