using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class TlbInsuranceType
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? Name { get; set; }

    public int Age { get; set; }

    public virtual ICollection<TlbInsurence> TlbInsurences { get; set; } = new List<TlbInsurence>();
}
