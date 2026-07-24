using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbArrivalGood
{
    public int RecieptId { get; set; }

    public string? DelivererPerson { get; set; }

    public string? TransfereePerson { get; set; }

    public DateTime ArrivalDate { get; set; }

    public TimeOnly ArrivalTime { get; set; }

    public int StockId { get; set; }

    public int Count { get; set; }

    public string? Discription { get; set; }

    public virtual TlbStock Stock { get; set; } = null!;
}
