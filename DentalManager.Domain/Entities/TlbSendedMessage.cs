using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbSendedMessage
{
    public int Id { get; set; }

    public long UserId { get; set; }

    public string? Text { get; set; }

    public bool Status { get; set; }

    public DateTime SendDateTime { get; set; }
}
