using CodeInspector.Application.DTOs;
using CodeInspector.Application.Interfaces;
using CodeInspector.Data.Entities;
using CodeInspector.Data.UnitOfWork;

namespace CodeInspector.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDto> SaveGitHubUserAsync(UserDto dto)
    {
        var user =
            await _unitOfWork.Users
                .GetByGitHubIdAsync(dto.GitHubId);

        if (user == null)
        {
            user = new User
            {
                Id = Guid.NewGuid(),

                GitHubId = dto.GitHubId,

                UserName = dto.UserName,

                Name = dto.Name,

                Email = dto.Email,

                AvatarUrl = dto.AvatarUrl
            };

            await _unitOfWork.Users.AddAsync(user);
        }
        else
        {
            user.UserName = dto.UserName;

            user.Name = dto.Name;

            user.Email = dto.Email;

            user.AvatarUrl = dto.AvatarUrl;

            _unitOfWork.Users.Update(user);
        }

        await _unitOfWork.SaveChangesAsync();

        return dto;
    }
}