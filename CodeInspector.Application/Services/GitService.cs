using System.Diagnostics;
using CodeInspector.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CodeInspector.Application.Services;

public class GitService : IGitService
{
    private readonly string _workspace;

    public GitService(IConfiguration configuration)
    {
        _workspace = configuration["Scanner:Workspace"]
            ?? throw new InvalidOperationException("Scanner workspace is not configured.");

        Directory.CreateDirectory(_workspace);
    }

    public async Task<string> CloneRepositoryAsync(
        string repositoryUrl,
        string branch = "main")
    {
        var folder = Path.Combine(
            _workspace,
            Guid.NewGuid().ToString());

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = $"clone --branch {branch} \"{repositoryUrl}\" \"{folder}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();

        string output = await process.StandardOutput.ReadToEndAsync();
        string error = await process.StandardError.ReadToEndAsync();

        await process.WaitForExitAsync();

        if (process.ExitCode != 0)
        {
            throw new Exception(error);
        }

        return folder;
    }

    public Task DeleteRepositoryAsync(string folderPath)
    {
        if (Directory.Exists(folderPath))
        {
            Directory.Delete(folderPath, true);
        }

        return Task.CompletedTask;
    }
}