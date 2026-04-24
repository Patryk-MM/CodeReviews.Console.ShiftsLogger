using ShiftsLogger.API.Patryk_MM.Models;

namespace ShiftsLogger.API.Patryk_MM.Repositories;

public class ShiftRepository : BaseRepository<Shift>, IShiftRepository {

    public ShiftRepository(AppDbContext _dbContext) : base(_dbContext) {
        
    }
}
