using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbMainCash
{
    public int FundId { get; set; }

    public string FundName { get; set; } = null!;

    public short FundType { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public bool? SetDefault { get; set; }

    public string? AccountDetailCode { get; set; }

    public int OfficeId { get; set; }

    public virtual TlbOfficeBuilding Office { get; set; } = null!;

    public virtual ICollection<TlbBankAccount> TlbBankAccounts { get; set; } = new List<TlbBankAccount>();

    public virtual ICollection<TlbTransaction> TlbTransactions { get; set; } = new List<TlbTransaction>();

    public virtual ICollection<TlbposDevice> TlbposDevices { get; set; } = new List<TlbposDevice>();
}
