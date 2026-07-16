namespace CodeInspector.Data.Entities;

public class User
{
    public Guid Id { get; set; }

    public string GitHubId { get; set; } = "";

    public string UserName { get; set; } = "";

    public string Name { get; set; } = "";

    public string Email { get; set; } = "";

    public string AvatarUrl { get; set; } = "";

    public bool IsActive { get; set; } = true;

    public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;

    public ICollection<Repository> Repositories
    {
        get;
        set;
    } = new List<Repository>();
}