namespace DentalManager.Application.DTOs.Staff;

public class StaffQueryDto
{
    public string? Search { get; set; }
    public string? Role { get; set; }          // all|doctor|staff
    public string? ActiveFilter { get; set; }  // all|active|inactive
    public string? ContractFilter { get; set; }// all|has-contract|no-contract
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}