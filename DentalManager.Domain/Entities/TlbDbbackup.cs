using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbDbbackup
{
    public int Id { get; set; }

    public string? FileName { get; set; }

    public DateTime CreateDatetime { get; set; }

    public string? PathDownload { get; set; }

    public bool Method { get; set; }
}
