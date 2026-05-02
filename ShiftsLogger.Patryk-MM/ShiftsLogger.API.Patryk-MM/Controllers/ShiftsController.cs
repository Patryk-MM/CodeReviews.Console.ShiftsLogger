using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.API.Patryk_MM.DTOs;
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
	[ProducesResponseType(typeof(PaginatedResult<IEnumerable<ShiftDTO>>), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> GetPaginatedShifts(int pageNumber = 1, int pageSize = 10) {
		var result = await _service.GetPaginatedShifts(pageNumber, pageSize);

		if (!result.IsSuccess) {
			return BadRequest(result.Error);
		}
		return Ok(result);
	}

	[HttpGet("{id}")]
	[ProducesResponseType(typeof(Result<ShiftDTO>), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetShiftByID(Guid id) {
		var result = await _service.GetShiftById(id);

		if (!result.IsSuccess) {
			return NotFound(result.Error);
		}
		return Ok(result);
	}

	[HttpPost()]
	[ProducesResponseType(typeof(Result<Shift>), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> CreateShift(CreateShiftDTO dto) {
		var result = await _service.CreateShift(dto);

		if (!result.IsSuccess) {
			return BadRequest(result.Error);
		}

		return CreatedAtAction(nameof(GetShiftByID), new { result.Data?.Id }, result);
	}

	[HttpDelete("{id}")]
	[ProducesResponseType(typeof(Result), StatusCodes.Status204NoContent)]
	[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> DeleteShift(Guid id) {
		var result = await _service.DeleteShift(id);

		if (!result.IsSuccess) {
			return BadRequest(result.Error);
		}

		return NoContent();
	}

	[HttpPut("{id}")]
	[ProducesResponseType(typeof(Result), StatusCodes.Status204NoContent)]
	[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> UpdateShift(Guid id, UpdateShiftDTO dto) {
		var result = await _service.UpdateShift(id, dto);

		if (!result.IsSuccess) {
			return BadRequest(result.Error);
		}

		return NoContent();
	}
}
