using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class Payroll
{
    public long Id { get; set; }

    public string? EmployeeId { get; set; }

    public DateTime PayrollDate { get; set; }

    public int Year { get; set; }

    public int Month { get; set; }

    public decimal TotalEarnings { get; set; }

    public decimal TotalDeductions { get; set; }

    public decimal NetSalary { get; set; }

    public int WorkingDays { get; set; }

    public int AbsentDays { get; set; }

    public decimal OverTimeHours { get; set; }

    public decimal HolidayHours { get; set; }

    public short State { get; set; }

    public virtual ApplicationUser? Employee { get; set; }

    public virtual ICollection<PayrollItem> PayrollItems { get; set; } = new List<PayrollItem>();

    public virtual ICollection<SalaryPayment> SalaryPayments { get; set; } = new List<SalaryPayment>();
}
