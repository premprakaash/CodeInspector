namespace CodeInspector.Data.Entities;

public class Repository
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; } = "";

    public string FullName { get; set; } = "";

    public string Url { get; set; } = "";

    public string DefaultBranch { get; set; } = "main";

    public bool IsPrivate { get; set; }

    public DateTime AddedOn { get; set; }
        = DateTime.UtcNow;

    public User User { get; set; } = null!;

    public ICollection<Scan> Scans
    {
        get;
        set;
    } = new List<Scan>();
}