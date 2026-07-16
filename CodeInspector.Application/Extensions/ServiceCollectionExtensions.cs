using CodeInspector.Application.Interfaces;
using CodeInspector.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodeInspector.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddHttpClient<IGitHubService, GitHubService>();
        services.AddScoped<IGitService, GitService>();

        return services;
    }
}