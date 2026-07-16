using CodeInspector.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeInspector.Data.Repositories;

public class BaseRepository<T>
    : IBaseRepository<T>
    where T : class
{
    protected readonly ApplicationDbContext Context;

    protected readonly DbSet<T> Table;

    public BaseRepository(
        ApplicationDbContext context)
    {
        Context = context;

        Table = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await Table.FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await Table.ToListAsync();
    }

    public async Task<List<T>> FindAsync(
        Expression<Func<T, bool>> predicate)
    {
        return await Table
            .Where(predicate)
            .ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task AddRangeAsync(
        IEnumerable<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        Table.Update(entity);
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }
}