using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbposDevice
{
    public int PosDeviceId { get; set; }

    public string Title { get; set; } = null!;

    public string? TerminalId { get; set; }

    public string? MerchantName { get; set; }

    public string? MerchantId { get; set; }

    public string? AccountDetailCode { get; set; }

    public string? Color { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public int BankId { get; set; }

    public int FundId { get; set; }

    public virtual TlbBank Bank { get; set; } = null!;

    public virtual TlbMainCash Fund { get; set; } = null!;
}
