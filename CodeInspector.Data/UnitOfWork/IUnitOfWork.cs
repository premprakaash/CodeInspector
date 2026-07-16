using CodeInspector.Data.Repositories;

namespace CodeInspector.Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }

    Task<int> SaveChangesAsync();
}