namespace CodeInspector.Api.Models;

public class GitHubUser
{
    public long Id { get; set; }

    public string Login { get; set; } = "";

    public string Name { get; set; } = "";

    public string Email { get; set; } = "";

    public string AvatarUrl { get; set; } = "";
}