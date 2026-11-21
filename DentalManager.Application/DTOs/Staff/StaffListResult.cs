namespace DentalManager.Application.DTOs.Staff;

public class StaffListResult
{
    public List<StaffDto> Items { get; set; } = new();
    public int Total { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => PageSize == 0 ? 1 : (int)Math.Ceiling((double)Total / PageSize);

    // برای KPI ها
    public int DoctorsCount { get; set; }
    public int StaffCount { get; set; }
    public int PresentToday { get; set; }
    public int AbsentToday { get; set; }
    public int ActiveContracts { get; set; }
}