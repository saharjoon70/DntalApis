using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbCost
{
    public int Id { get; set; }

    public double PaidCost { get; set; }

    public DateTime RegisterDate { get; set; }

    public virtual ICollection<TlbCostPaysDetail> TlbCostPaysDetails { get; set; } = new List<TlbCostPaysDetail>();

    public virtual TlbEmployeeCost? TlbEmployeeCost { get; set; }

    public virtual TlbFactorsCost? TlbFactorsCost { get; set; }

    public virtual TlbLabOrder? TlbLabOrder { get; set; }
}
