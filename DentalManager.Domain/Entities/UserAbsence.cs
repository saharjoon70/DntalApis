using System;

namespace DentalManager.Domain.Entities;

/// <summary>
/// غیبت یا مرخصی هر پرسنل.
/// </summary>
public class UserAbsence
{
    public long Id { get; set; }

    /// <summary>FK به AspNetUsers.Id</summary>
    public string UserId { get; set; } = null!;

    public DateTime Date { get; set; }

    public string? Reason { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
}