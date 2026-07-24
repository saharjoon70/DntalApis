using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbStock
{
    public int Id { get; set; }

    public int Groupid { get; set; }

    public string? Name { get; set; }

    public string? SerialNumber { get; set; }

    public string? Brand { get; set; }

    public int Storage { get; set; }

    public string? Country { get; set; }

    public int MaxInventory { get; set; }

    public int MinInventory { get; set; }

    public int WarehouseId { get; set; }

    public DateTime ExpiresionsDate { get; set; }

    public DateTime ProductionsDate { get; set; }

    public double Cost { get; set; }

    public string? Company { get; set; }

    public DateTime RegistersDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual TlbStockGroup Group { get; set; } = null!;

    public virtual ICollection<TlbArrivalGood> TlbArrivalGoods { get; set; } = new List<TlbArrivalGood>();

    public virtual ICollection<TlbExitGood> TlbExitGoods { get; set; } = new List<TlbExitGood>();

    public virtual TlbWarehouse Warehouse { get; set; } = null!;
}
