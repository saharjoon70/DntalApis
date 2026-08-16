using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;
public partial class DashboardSummery
{
    public string Id { get; set; } = null!;

    public decimal? TodayIncome { get; set; }
}
