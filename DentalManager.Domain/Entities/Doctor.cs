namespace DentalManager.Domain.Entities;

/// <summary>
/// اطلاعات اختصاصی پزشک (1:1 با ApplicationUser).
/// </summary>
public class Doctor
{
    public long Id { get; set; }

    /// <summary>FK به AspNetUsers.Id (unique)</summary>
    public string UserId { get; set; } = null!;

    /// <summary>شماره نظام پزشکی</summary>
    public string? MedicalCode { get; set; }

    /// <summary>تخصص - مثلاً "ترمیمی"، "ارتودنسی"</summary>
    public string? Specialty { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
}