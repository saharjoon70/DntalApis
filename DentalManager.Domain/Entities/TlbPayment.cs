using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbPayment
{
    public string Id { get; set; } = null!;

    public long Key { get; set; }

    public long? RsvId { get; set; }

    public long FolderId { get; set; }

    public double PayAmount { get; set; }

    public short PayMethod { get; set; }

    public DateTime PayDateTime { get; set; }

    public string? TitlePay { get; set; }

    public virtual TlbPatientsFolder Folder { get; set; } = null!;

    public virtual TlbReserf? Rsv { get; set; }
}
