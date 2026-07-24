using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbCostPaysDetail
{
    public int Id { get; set; }

    public int CostRIdForignKey { get; set; }

    public short MethodPayment { get; set; }

    public double AmountPayment { get; set; }

    public DateTime PayDate { get; set; }

    public virtual TlbCost CostRIdForignKeyNavigation { get; set; } = null!;
}
