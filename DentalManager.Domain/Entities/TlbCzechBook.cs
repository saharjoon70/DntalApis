using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbCzechBook
{
    public int Id { get; set; }

    public string? IssuerName { get; set; }

    public long FolderId { get; set; }

    public double Amount { get; set; }

    public DateTime Expiration { get; set; }

    public DateTime RecieveDate { get; set; }

    public string? Bank { get; set; }

    public string? City { get; set; }

    public string? Branch { get; set; }

    public string? AccountNumber { get; set; }

    public long SerialNumber { get; set; }

    public string? Discription { get; set; }

    public short Status { get; set; }

    public virtual TlbPatientsFolder Folder { get; set; } = null!;
}
