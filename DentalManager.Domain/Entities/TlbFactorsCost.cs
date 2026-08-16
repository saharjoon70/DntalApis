using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbFactorsCost
{
    public int Id { get; set; }

    public short Type { get; set; }

    public int FactorId { get; set; }

    public int CostId { get; set; }

    public string? Title { get; set; }

    public string? Discription { get; set; }

    public double SumCost { get; set; }

    public string? Receiver { get; set; }

    public long DoctorId { get; set; }

    public DateTime RegisterDate { get; set; }

    public virtual TlbCost Cost { get; set; } = null!;

    public virtual TlbDoctor Doctor { get; set; } = null!;
}
