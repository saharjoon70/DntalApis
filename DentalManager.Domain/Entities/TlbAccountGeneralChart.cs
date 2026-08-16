using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbAccountGeneralChart
{
    public string AccountCode { get; set; } = null!;

    public string? AccountName { get; set; }

    public int AccountType { get; set; }

    public string? HeadAccountCode { get; set; }

    public string? RootHeadCode { get; set; }

    public string? Discription { get; set; }
}
