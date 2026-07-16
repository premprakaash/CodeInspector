namespace CodeInspector.Application.DTOs;

public class GitHubRepositoryDto
{
    public long Id { get; set; }

    public string Name { get; set; } = "";

    public string FullName { get; set; } = "";

    public string HtmlUrl { get; set; } = "";

    public bool Private { get; set; }

    public string DefaultBranch { get; set; } = "";

    public string Language { get; set; } = "";
}