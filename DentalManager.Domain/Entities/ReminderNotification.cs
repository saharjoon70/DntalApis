using System;
using System.Collections.Generic;

namespace DentalManager.Domain.Entities;

public partial class ReminderNotification
{
    public int Id { get; set; }

    public string? Userid { get; set; }

    public string? Discripton { get; set; }

    public string? Title { get; set; }

    public DateTime Date { get; set; }

    public TimeOnly Time { get; set; }

    public string? Type { get; set; }

    public bool Status { get; set; }
}
