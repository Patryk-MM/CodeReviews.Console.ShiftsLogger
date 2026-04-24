using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.API.Patryk_MM.Models;
using ShiftsLogger.API.Patryk_MM.Repositories;
using System.Net;

namespace ShiftsLogger.API.Patryk_MM.Services;

public class ShiftService {

    private readonly ShiftRepository _repository;

    public ShiftService(ShiftRepository repository) {
        _repository = repository;
    }

    public async Task<List<Shift>> GetAllShifts() {
        return await _repository.GetAllAsync();
    }

    public async Task<ServiceResponse<Shift>> CreateShift(DateTime start, DateTime end) {
        ServiceResponse<Shift> response = new ServiceResponse<Shift>();

        if (start > end) {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.Message = "End time cannot be before start time";
            return response;
        }
        Shift shift = new Shift {
            Id = Guid.NewGuid(),
            Start = start,
            End = end
        };


        try {
            await _repository.AddAsync(shift);
            response.Success = true;
            response.Data = shift;
            response.ResponseCode = HttpStatusCode.Created;
            return response;
        }
        catch (Exception ex) {
            response.ResponseCode = HttpStatusCode.InternalServerError;
            response.Message = ex.Message;
            return response;
        }
    }
}
