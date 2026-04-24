using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.API.Patryk_MM.Models;
using ShiftsLogger.API.Patryk_MM.Services;
using System.Threading.Tasks;

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
        List<Shift> shifts = await _service.GetAllShifts();

        return Ok(shifts);
    }

    [HttpPost()]
    public async Task<IActionResult> CreateShift(DateTime start, DateTime end) {
        ServiceResponse<Shift> response = await _service.CreateShift(start, end);

        return StatusCode((int)response.ResponseCode, response.Data);
    }
}
