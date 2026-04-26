using Microsoft.EntityFrameworkCore;
using ShiftsLogger.API.Patryk_MM.Models;
using System.Linq.Expressions;

namespace ShiftsLogger.API.Patryk_MM.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity {

    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(AppDbContext context) {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity) {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity) {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task EditAsync(T entity) {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync() {
        return await _dbSet.ToListAsync();
    }

    public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate) {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id) {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
    }
}
