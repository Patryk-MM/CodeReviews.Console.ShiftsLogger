using ShiftsLogger.API.Patryk_MM.Models;

namespace ShiftsLogger.API.Patryk_MM.Repositories;

public interface IShiftRepository : IBaseRepository<Shift> {
    Task<IEnumerable<Shift>> GetPaginatedShiftsAsync(int pageNumber, int pageSize);
}
