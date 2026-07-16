using CodeInspector.Application.DTOs;

namespace CodeInspector.Application.Interfaces;

public interface IGitHubService
{
    Task<List<GitHubRepositoryDto>> GetRepositoriesAsync(
        string accessToken);
}