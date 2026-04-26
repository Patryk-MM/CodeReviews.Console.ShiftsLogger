using ShiftsLogger.API.Patryk_MM.Models;
using ShiftsLogger.API.Patryk_MM.Repositories;
using ShiftsLogger.API.Patryk_MM.Shared;
using System.Net;

namespace ShiftsLogger.API.Patryk_MM.Services;

public class ShiftService {

    private readonly ShiftRepository _repository;

    public ShiftService(ShiftRepository repository) {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<Shift>>> GetAllShifts() {
        IEnumerable<Shift> shifts = await _repository.GetAllAsync();
        return Result.Success(shifts);
    }

    public async Task<Result<Shift>> GetShiftById(Guid id) {
        Shift shift = await _repository.GetByIdAsync(id);

        if (shift is null) return Result.Failure<Shift>($"Shift with Id {id} was not found.");

        return Result.Success(shift);
    }

    public async Task<Result<Shift>> CreateShift(DateTime start, DateTime end) {
        if (start > end) {
            return Result.Failure<Shift>("End time cannot be before start time.");
        }

        Shift shift = new Shift {
            Id = Guid.NewGuid(),
            Start = start,
            End = end,
        };

        await _repository.AddAsync(shift);
        return Result.Success(shift);

    }
}
