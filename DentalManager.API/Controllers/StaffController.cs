using DentalManager.Application.DTOs.Staff;
using DentalManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.API.Controllers;

[ApiController]
[Route("api/staff")]
[Authorize(Roles = "Admin,SuperAdmin")]
public class StaffController : ControllerBase
{
    private readonly IStaffService _service;
    public StaffController(IStaffService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<StaffListResult>> GetList([FromQuery] StaffQueryDto query, CancellationToken ct)
        => Ok(await _service.GetListAsync(query, ct));

    [HttpGet("{id}")]
    public async Task<ActionResult<StaffDto>> GetById(string id, CancellationToken ct)
    {
        var dto = await _service.GetByIdAsync(id, ct);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpPost("doctor")]
    public async Task<ActionResult<StaffDto>> CreateDoctor([FromBody] StaffCreateDoctorDto dto, CancellationToken ct)
    {
        var result = await _service.CreateDoctorAsync(dto, ct);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPost("employee")]
    public async Task<ActionResult<StaffDto>> CreateEmployee([FromBody] StaffCreateEmployeeDto dto, CancellationToken ct)
    {
        var result = await _service.CreateEmployeeAsync(dto, ct);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<StaffDto>> Update(string id, [FromBody] StaffUpdateDto dto, CancellationToken ct)
        => Ok(await _service.UpdateAsync(id, dto, ct));

    [HttpPatch("{id}/toggle-active")]
    public async Task<ActionResult<object>> ToggleActive(string id, CancellationToken ct)
    {
        var isActive = await _service.ToggleActiveAsync(id, ct);
        return Ok(new { isActive });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        await _service.DeleteAsync(id, ct);
        return NoContent();
    }

    [HttpPost("bulk-delete")]
    public async Task<ActionResult<object>> BulkDelete([FromBody] List<string> ids, CancellationToken ct)
    {
        var deleted = await _service.BulkDeleteAsync(ids, ct);
        return Ok(new { deleted });
    }

    // ⭐ جدید: ارسال مجدد اطلاعات ورود
    [HttpPost("{id}/resend-credentials")]
    public async Task<ActionResult<StaffDto>> ResendCredentials(string id, CancellationToken ct)
    {
        var result = await _service.ResendCredentialsAsync(id, ct);
        return Ok(result);
    }
}