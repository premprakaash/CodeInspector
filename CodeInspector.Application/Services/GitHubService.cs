using CodeInspector.Application.DTOs;
using CodeInspector.Application.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CodeInspector.Application.Services;

public class GitHubService : IGitHubService
{
    private readonly HttpClient _httpClient;

    public GitHubService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<GitHubRepositoryDto>> GetRepositoriesAsync(
        string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Clear();

        _httpClient.DefaultRequestHeaders.UserAgent.Add(
            new ProductInfoHeaderValue("CodeInspector", "1.0"));

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await _httpClient.GetAsync(
            "https://api.github.com/user/repos?per_page=100&sort=updated");

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var repositories =
            JsonSerializer.Deserialize<List<GitHubRepositoryDto>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        return repositories ?? new List<GitHubRepositoryDto>();
    }
}