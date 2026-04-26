using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.API.Patryk_MM.Models;
using ShiftsLogger.API.Patryk_MM.Services;
using ShiftsLogger.API.Patryk_MM.Shared;

namespace ShiftsLogger.API.Patryk_MM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShiftsController : ControllerBase {
    private readonly ILogger<ShiftsController> _logger;
    private readonly ShiftService _service;

    public ShiftsController(ShiftService service, ILogger<ShiftsController> logger) {
        _service = service;
        _logger = logger;
    }

    [HttpGet()]
    public async Task<IActionResult> GetShifts() {
        var result = await _service.GetAllShifts();

        if (!result.IsSuccess) {
            return BadRequest(result.Error);
        }
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetShiftByID(Guid id) {
        var result = await _service.GetShiftById(id);

        if (!result.IsSuccess) return NotFound(result.Error);
        return Ok(result);
    }

    [HttpPost()]
    public async Task<IActionResult> CreateShift(DateTime start, DateTime end) {
        var result = await _service.CreateShift(start, end);

        if (!result.IsSuccess) {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(GetShiftByID), new { result.Data?.Id }, result);
    }
}
