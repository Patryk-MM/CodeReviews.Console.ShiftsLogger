using ShiftsLogger.API.Patryk_MM.DTOs;
using ShiftsLogger.API.Patryk_MM.Models;

namespace ShiftsLogger.API.Patryk_MM.Mappers;

public static class MapMethods {
    public static ShiftDTO ToDTO(this Shift shift) {
        return new ShiftDTO {
            Id = shift.Id,
            Start = shift.Start,
            End = shift.End,
        };
    }
}
