namespace CodeInspector.Data.Entities;

public class Scan
{
    public Guid Id { get; set; }

    public Guid RepositoryId { get; set; }

    public DateTime ScanDate { get; set; }
        = DateTime.UtcNow;

    public int TotalFiles { get; set; }

    public int TotalIssues { get; set; }

    public int Critical { get; set; }

    public int High { get; set; }

    public int Medium { get; set; }

    public int Low { get; set; }

    public string Status { get; set; } = "Completed";

    public Repository Repository { get; set; } = null!;

    public ICollection<Issue> Issues
    {
        get;
        set;
    } = new List<Issue>();
}