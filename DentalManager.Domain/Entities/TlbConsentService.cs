using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbConsentService
{
    public int Id { get; set; }

    public int TypeService { get; set; }

    public string? Content { get; set; }
}
