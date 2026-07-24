using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class BankAccountStaff
{
    public int BankAccountId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public string? Iban { get; set; }

    public string? CardNumber { get; set; }

    public string? AccountDetailCode { get; set; }

    public DateTime CreateDate { get; set; }

    public int BankId { get; set; }

    public string StaffId { get; set; } = null!;

    public virtual TlbBank Bank { get; set; } = null!;

    public virtual AspNetUser Staff { get; set; } = null!;
}
