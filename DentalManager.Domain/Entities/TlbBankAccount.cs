using System;
using System.Collections.Generic;
namespace DentalManager.Domain.Entities;

public partial class TlbBankAccount
{
    public int BankAccountId { get; set; }

    public string Owenr { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public string? Iban { get; set; }

    public string? CardNumber { get; set; }

    public string? ExpirationDate { get; set; }

    public string? AccountDetailCode { get; set; }

    public bool IsActive { get; set; }

    public string? Color { get; set; }

    public int BankId { get; set; }

    public int FundId { get; set; }

    public virtual TlbBank Bank { get; set; } = null!;

    public virtual TlbMainCash Fund { get; set; } = null!;
}
