using System.Linq.Expressions;

namespace CodeInspector.Data.Repositories;

public interface IBaseRepository<T>
    where T : class
{
    Task<T?> GetByIdAsync(Guid id);

    Task<List<T>> GetAllAsync();

    Task<List<T>> FindAsync(
        Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    void Update(T entity);

    void Delete(T entity);

    Task<int> SaveChangesAsync();
}