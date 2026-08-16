using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbEmployee
{
    public long Id { get; set; }

    public double SalaryBase { get; set; }

    public double SalaryHourly { get; set; }

    public virtual ICollection<TlbEmployeeCost> TlbEmployeeCosts { get; set; } = new List<TlbEmployeeCost>();
}
