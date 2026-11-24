using DentalManager.Application.DTOs.Staff;

namespace DentalManager.Application.Interfaces;

public interface IStaffService
{
    Task<StaffListResult> GetListAsync(StaffQueryDto query, CancellationToken ct = default);
    Task<StaffDto?> GetByIdAsync(string id, CancellationToken ct = default);
    Task<StaffDto> CreateDoctorAsync(StaffCreateDoctorDto dto, CancellationToken ct = default);
    Task<StaffDto> CreateEmployeeAsync(StaffCreateEmployeeDto dto, CancellationToken ct = default);
    Task<StaffDto> UpdateAsync(string id, StaffUpdateDto dto, CancellationToken ct = default);
    Task<bool> ToggleActiveAsync(string id, CancellationToken ct = default);
    Task DeleteAsync(string id, CancellationToken ct = default);
    Task<int> BulkDeleteAsync(IEnumerable<string> ids, CancellationToken ct = default);
    Task<StaffDto> ResendCredentialsAsync(string id, CancellationToken ct = default);
}