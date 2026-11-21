namespace DentalManager.Domain.Entities;

/// <summary>
/// اطلاعات اختصاصی کارمند غیرپزشک (1:1 با ApplicationUser).
/// </summary>
public class Employee
{
    public long Id { get; set; }

    /// <summary>FK به AspNetUsers.Id (unique)</summary>
    public string UserId { get; set; } = null!;

    /// <summary>سمت - منشی | دستیار | پذیرش | حسابداری | خدمات</summary>
    public string? Position { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
}