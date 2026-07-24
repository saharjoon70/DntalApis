using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class SalaryPayment
{
    public long Id { get; set; }

    public long PayrollId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public long TransactionId { get; set; }

    public virtual Payroll Payroll { get; set; } = null!;

    public virtual TlbTransaction Transaction { get; set; } = null!;
}
