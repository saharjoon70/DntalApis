using System.ComponentModel.DataAnnotations;

namespace DentalManager.Application.DTOs.Staff;

public class StaffCreateDoctorDto
{
    [Required, MaxLength(100)] public string FirstName { get; set; } = null!;
    [Required, MaxLength(100)] public string LastName { get; set; } = null!;
    [Required, MaxLength(50)] public string MedicalCode { get; set; } = null!;
    [Required, MaxLength(200)] public string Specialty { get; set; } = null!;
    [Required, MaxLength(11)] public string Phone { get; set; } = null!;
    [MaxLength(10)] public string? NationalCode { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool Gender { get; set; }              // true=مرد false=زن
    [EmailAddress] public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Landline { get; set; }
    /// <summary>اگر خالی باشد، DefaultPassword استفاده می‌شود.</summary>
    public string? Password { get; set; }
}