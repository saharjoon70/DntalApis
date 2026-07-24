using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbInsurenceConsume
{
    public int Id { get; set; }

    public long ReserveCode { get; set; }

    public double AmountComsume { get; set; }

    public DateTime DateComsume { get; set; }

    public string? ClinicName { get; set; }

    public virtual TlbReserf ReserveCodeNavigation { get; set; } = null!;
}
