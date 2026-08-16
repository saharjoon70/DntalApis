using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbOfficePlan
{
    public int Id { get; set; }

    public string? PlanName { get; set; }

    public int Count { get; set; }

    public double Price { get; set; }

    public int ActiveDate { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<TlbOfficeBuilding> TlbOfficeBuildings { get; set; } = new List<TlbOfficeBuilding>();
}
