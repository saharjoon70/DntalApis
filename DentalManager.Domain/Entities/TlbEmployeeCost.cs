using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbEmployeeCost
{
    public int Id { get; set; }

    public int CostId { get; set; }

    public string? Title { get; set; }

    public string? Discription { get; set; }

    public double InsuranceAmount { get; set; }

    public long EmployerId { get; set; }

    public virtual TlbCost Cost { get; set; } = null!;

    public virtual TlbEmployee Employer { get; set; } = null!;
}
