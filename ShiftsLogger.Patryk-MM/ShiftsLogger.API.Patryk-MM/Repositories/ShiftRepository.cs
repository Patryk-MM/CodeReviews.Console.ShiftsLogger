using Microsoft.EntityFrameworkCore;
using ShiftsLogger.API.Patryk_MM.Models;

namespace ShiftsLogger.API.Patryk_MM.Repositories;

public class ShiftRepository : BaseRepository<Shift>, IShiftRepository {

    public ShiftRepository(AppDbContext _dbContext) : base(_dbContext) {
        
    }

    public async Task<IEnumerable<Shift>> GetPaginatedShifstAsync(int pageNumber, int pageSize) {
        return await _dbSet
            .OrderBy(s => s.Start)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}
