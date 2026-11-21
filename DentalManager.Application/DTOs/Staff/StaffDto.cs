namespace DentalManager.Application.DTOs.Staff;

public class StaffDto
{
    public string Id { get; set; } = null!;
    public string FullName { get; set; } = "";
    public string Role { get; set; } = "staff";  // "doctor" | "staff"
    public string? RoleName { get; set; }               // ADMIN | SECRETARY | DOCTOR | ...
    public string? RoleFaName { get; set; }
    // پزشک
    public string? MedicalCode { get; set; }
    public string? Specialty { get; set; }

    // کارمند
    public string? Position { get; set; }

    // مشترک
    public string? NationalCode { get; set; }
    public DateTime? BirthDate { get; set; }
    public int? Age { get; set; }
    public string? Gender { get; set; }          // "male" | "female"
    public string? Phone { get; set; }
    public string? Landline { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Photo { get; set; }
    public bool Active { get; set; }

    // خلاصه قرارداد
    public string ContractStatus { get; set; } = "none"; // none|active|expired|terminated
    public int ContractCount { get; set; }

    public DateTime CreatedAt { get; set; }
}