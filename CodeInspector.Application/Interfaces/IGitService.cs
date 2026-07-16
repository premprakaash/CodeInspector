namespace CodeInspector.Application.Interfaces;

public interface IGitService
{
    Task<string> CloneRepositoryAsync(
        string repositoryUrl,
        string branch = "main");

    Task DeleteRepositoryAsync(
        string folderPath);
}