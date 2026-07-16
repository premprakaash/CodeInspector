using CodeInspector.Application.DTOs;

namespace CodeInspector.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> SaveGitHubUserAsync(UserDto user);
}