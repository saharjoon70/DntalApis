using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbDbpatternMessage
{
    public int Id { get; set; }

    public string? PtrCode { get; set; }

    public string? Text { get; set; }

    public string? Title { get; set; }

    public int Type { get; set; }
}
