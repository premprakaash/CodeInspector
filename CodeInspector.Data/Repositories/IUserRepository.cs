using CodeInspector.Data.Entities;

namespace CodeInspector.Data.Repositories;

public interface IUserRepository
    : IBaseRepository<User>
{
    Task<User?> GetByGitHubIdAsync(
        string githubId);

    Task<User?> GetByEmailAsync(
        string email);
}