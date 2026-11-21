namespace DentalManager.Domain.Entities;

/// <summary>
/// شیفت هفتگی هر پرسنل.
/// </summary>
public class UserShift
{
    public long Id { get; set; }

    /// <summary>FK به AspNetUsers.Id</summary>
    public string UserId { get; set; } = null!;

    /// <summary>0=شنبه ... 6=جمعه</summary>
    public int DayOfWeek { get; set; }

    /// <summary>morning | evening | off</summary>
    public string ShiftType { get; set; } = "off";

    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
}