namespace DentalManager.Application.DTOs.Staff;

public class StaffUpdateDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MedicalCode { get; set; }
    public string? Specialty { get; set; }
    public string? Position { get; set; }
    public string? NationalCode { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool? Gender { get; set; }
    public string? Phone { get; set; }
    public string? Landline { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}