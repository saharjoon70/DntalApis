using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbBank
{
    public int BankId { get; set; }

    public string BankName { get; set; } = null!;

    public string? Logo { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual ICollection<BankAccountStaff> BankAccountStaffs { get; set; } = new List<BankAccountStaff>();

    public virtual ICollection<TlbBankAccount> TlbBankAccounts { get; set; } = new List<TlbBankAccount>();

    public virtual ICollection<TlbposDevice> TlbposDevices { get; set; } = new List<TlbposDevice>();
}
