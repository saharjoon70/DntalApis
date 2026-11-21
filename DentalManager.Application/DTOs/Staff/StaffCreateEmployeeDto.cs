using System.ComponentModel.DataAnnotations;

namespace DentalManager.Application.DTOs.Staff;

public class StaffCreateEmployeeDto
{
    [Required, MaxLength(100)] public string FirstName { get; set; } = null!;
    [Required, MaxLength(100)] public string LastName { get; set; } = null!;
    [Required, MaxLength(100)] public string Position { get; set; } = null!;
    [Required, MaxLength(11)] public string Phone { get; set; } = null!;
    [MaxLength(10)] public string? NationalCode { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool Gender { get; set; }
    [EmailAddress] public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Password { get; set; }
}