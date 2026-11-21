using DentalManager.Application.DTOs.Contracts;

namespace DentalManager.Application.Interfaces;

public interface IContractService
{
    Task<List<ContractDto>> GetByPersonAsync(string personId, CancellationToken ct = default);
    Task<ContractDto?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<ContractDto> CreateAsync(ContractCreateDto dto, CancellationToken ct = default);
    Task<ContractDto> UpdateAsync(int id, ContractUpdateDto dto, CancellationToken ct = default);
    Task<ContractDto> TerminateAsync(int id, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
}