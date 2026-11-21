namespace DentalManager.Domain.Entities;

public class Contract
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;

    public DateOnly StartDate { get; set; }
    public string Duration { get; set; } = "12";       // "3","6","12","24","0"
    public DateOnly? EndDate { get; set; }

    public string? ContractType { get; set; }          // fulltime|parttime|project|temporary|internship
    public string? JobTitle { get; set; }
    public string? Duties { get; set; }

    public string PaymentType { get; set; } = "monthly"; // monthly|daily|percentage|project|hybrid
    public decimal BaseSalary { get; set; }
    public decimal Commission { get; set; }
    public decimal Bonus { get; set; }
    public decimal Transport { get; set; }
    public decimal Overtime { get; set; }

    public string Insurance { get; set; } = "دارد";
    public string? CardNumber { get; set; }
    public string Tax { get; set; } = "none";          // none|included|excluded

    public string? ClausesJson { get; set; }

    /// <summary>active|terminated|expired (expired محاسبه‌شده در لایه سرویس)</summary>
    public string Status { get; set; } = "active";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? TerminatedAt { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
}