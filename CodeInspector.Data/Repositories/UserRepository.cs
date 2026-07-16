using CodeInspector.Data.Context;
using CodeInspector.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeInspector.Data.Repositories;

public class UserRepository
    : BaseRepository<User>,
      IUserRepository
{
    public UserRepository(
        ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<User?> GetByGitHubIdAsync(
        string githubId)
    {
        return await Context.Users
            .FirstOrDefaultAsync(
                x => x.GitHubId == githubId);
    }

    public async Task<User?> GetByEmailAsync(
        string email)
    {
        return await Context.Users
            .FirstOrDefaultAsync(
                x => x.Email == email);
    }
}