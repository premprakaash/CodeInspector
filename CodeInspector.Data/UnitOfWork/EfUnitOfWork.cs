using CodeInspector.Data.Context;
using CodeInspector.Data.Repositories;

namespace CodeInspector.Data.UnitOfWork;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IUserRepository Users { get; }

    public EfUnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        Users = new UserRepository(context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}