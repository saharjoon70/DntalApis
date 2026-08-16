using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbTransaction
{
    public long TransactionId { get; set; }

    public string? TrackingCode { get; set; }

    public double PayAmount { get; set; }

    public string? TitlePay { get; set; }

    public string? Details { get; set; }

    public DateTime PayDatetime { get; set; }

    public DateTime CreateDateTime { get; set; }

    public int FundId { get; set; }

    public string? AccountDetailCode { get; set; }

    public virtual TlbMainCash Fund { get; set; } = null!;

    public virtual ICollection<SalaryPayment> SalaryPayments { get; set; } = new List<SalaryPayment>();
}
