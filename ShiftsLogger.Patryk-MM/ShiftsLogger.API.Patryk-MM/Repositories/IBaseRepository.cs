using ShiftsLogger.API.Patryk_MM.Models;
using System.Linq.Expressions;

namespace ShiftsLogger.API.Patryk_MM.Repositories;

public interface IBaseRepository<T> where T : BaseEntity {
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task EditAsync(T entity);
}
