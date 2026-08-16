using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbInsurence
{
    public int Id { get; set; }

    public string? PreferentialCode { get; set; }

    public string? OrganizationCode { get; set; }

    public string? OrganizationName { get; set; }

    public int Contribution { get; set; }

    public bool State { get; set; }

    public int TypeId { get; set; }

    public double CreditLimit { get; set; }

    public DateTime RegisterTime { get; set; }

    public virtual ICollection<TlbInsurenceSrvice> TlbInsurenceSrvices { get; set; } = new List<TlbInsurenceSrvice>();

    public virtual TlbInsuranceType Type { get; set; } = null!;
}
