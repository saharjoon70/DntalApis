using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbInsurenceSrvice
{
    public int Id { get; set; }

    public int ServiceType { get; set; }

    public int InsuranceId { get; set; }

    public int? DentalServicesId { get; set; }

    public virtual TlbService? DentalServices { get; set; }

    public virtual TlbInsurence Insurance { get; set; } = null!;
}
