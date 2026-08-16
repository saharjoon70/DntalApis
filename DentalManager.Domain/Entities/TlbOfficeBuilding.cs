using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbOfficeBuilding
{
    public int Id { get; set; }

    public string? OfficeName { get; set; }

    public string? OfficeEname { get; set; }

    public string? OfficeAddress { get; set; }

    public string? OfficePhone { get; set; }

    public string? OfficeLogo { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? ManagerSignature { get; set; }

    public int Plan { get; set; }

    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();

    public virtual TlbOfficePlan PlanNavigation { get; set; } = null!;

    public virtual ICollection<TlbDoctor> TlbDoctors { get; set; } = new List<TlbDoctor>();

    public virtual ICollection<TlbMainCash> TlbMainCashes { get; set; } = new List<TlbMainCash>();
}
