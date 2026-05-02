using ShiftsLogger.API.Patryk_MM.DTOs;
using ShiftsLogger.API.Patryk_MM.Mappers;
using ShiftsLogger.API.Patryk_MM.Models;
using ShiftsLogger.API.Patryk_MM.Repositories;
using ShiftsLogger.API.Patryk_MM.Shared;

namespace ShiftsLogger.API.Patryk_MM.Services;

public class ShiftService {

	private readonly ShiftRepository _repository;

	public ShiftService(ShiftRepository repository) {
		_repository = repository;
	}

	public async Task<Result<IEnumerable<ShiftDTO>>> GetAllShifts() {
		IEnumerable<Shift> shifts = await _repository.GetAllAsync();

		IEnumerable<ShiftDTO> dtos = shifts.Select(s => s.ToDTO());

		return Result.Success(dtos);
	}

	public async Task<Result<IEnumerable<ShiftDTO>>> GetPaginatedShifts(int pageNumber, int pageSize) {
		IEnumerable<Shift> shifts = await _repository.GetPaginatedShiftsAsync(pageNumber, pageSize);

		IEnumerable<ShiftDTO> dtos = shifts.Select(s => s.ToDTO());

		return Result.Success(dtos, pageNumber, pageSize);
	}

	public async Task<Result<ShiftDTO>> GetShiftById(Guid id) {
		Shift? shift = await _repository.GetByIdAsync(id);

		if (shift is null) {
			return Result.Failure<ShiftDTO>($"Shift with Id {id} was not found.");
		}

		ShiftDTO dto = shift.ToDTO();

		return Result.Success(dto);
	}

	public async Task<Result<ShiftDTO>> CreateShift(CreateShiftDTO dto) {
		if (dto.Start > dto.End) {
			return Result.Failure<ShiftDTO>("End time cannot be before start time.");
		}

		Shift shift = new Shift {
			Id = Guid.NewGuid(),
			Start = dto.Start,
			End = dto.End,
		};

		await _repository.AddAsync(shift);
		return Result.Success(shift.ToDTO());
	}

	public async Task<Result> DeleteShift(Guid id) {
		Shift? shift = await _repository.GetByIdAsync(id);

		if (shift is null) {
			return Result.Failure($"Shift with Id {id} was not found.");
		}

		await _repository.DeleteAsync(shift);
		return Result.Success($"Shift {shift.Id} has been successfully deleted.");
	}

	public async Task<Result> UpdateShift(Guid id, UpdateShiftDTO dto) {
		if (dto.Start > dto.End) {
			return Result.Failure("End time cannot be before start time.");
		}

		Shift? shift = await _repository.GetByIdAsync(id);

		if (shift is null) {
			return Result.Failure($"Shift with Id {id} was not found.");
		}

		shift.Start = dto.Start;
		shift.End = dto.End;

		await _repository.EditAsync(shift);
		return Result.Success();
	}

}
