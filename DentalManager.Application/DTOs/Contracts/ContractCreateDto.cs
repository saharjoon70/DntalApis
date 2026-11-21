using System.ComponentModel.DataAnnotations;

namespace DentalManager.Application.DTOs.Contracts;

public class ContractCreateDto
{
    [Required] public string PersonId { get; set; } = null!;
    [Required] public string StartDate { get; set; } = null!;   // yyyy-MM-dd
    public string Duration { get; set; } = "12";
    public string? EndDate { get; set; }

    public string? ContractType { get; set; }
    public string? JobTitle { get; set; }
    public string? Duties { get; set; }
    public string PaymentType { get; set; } = "monthly";

    public decimal BaseSalary { get; set; }
    public decimal Commission { get; set; }
    public decimal Bonus { get; set; }
    public decimal Transport { get; set; }
    public decimal Overtime { get; set; }

    public string Insurance { get; set; } = "دارد";
    public string? CardNumber { get; set; }
    public string Tax { get; set; } = "none";

    public List<ContractClauseDto> Clauses { get; set; } = new();
}


public class ContractUpdateDto : ContractCreateDto { }