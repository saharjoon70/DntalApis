using DentalManager.Application.DTOs.Contracts;
using DentalManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.API.Controllers;

[ApiController]
[Route("api/contracts")]
[Authorize(Roles = "Admin,SuperAdmin")]
public class ContractsController : ControllerBase
{
    private readonly IContractService _service;
    public ContractsController(IContractService service) => _service = service;

    [HttpGet("by-person/{personId}")]
    public async Task<ActionResult<List<ContractDto>>> GetByPerson(string personId, CancellationToken ct)
        => Ok(await _service.GetByPersonAsync(personId, ct));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ContractDto>> GetById(int id, CancellationToken ct)
    {
        var dto = await _service.GetByIdAsync(id, ct);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<ContractDto>> Create([FromBody] ContractCreateDto dto, CancellationToken ct)
    {
        var result = await _service.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ContractDto>> Update(int id, [FromBody] ContractUpdateDto dto, CancellationToken ct)
        => Ok(await _service.UpdateAsync(id, dto, ct));

    [HttpPatch("{id:int}/terminate")]
    public async Task<ActionResult<ContractDto>> Terminate(int id, CancellationToken ct)
        => Ok(await _service.TerminateAsync(id, ct));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _service.DeleteAsync(id, ct);
        return NoContent();
    }
}