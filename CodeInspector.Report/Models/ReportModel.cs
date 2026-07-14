using CodeInspector.Models;

namespace CodeInspector.Report.Models;

public class ReportModel
{
    public string ProjectName { get; set; } = "";

    public DateTime ScanDate { get; set; }

    public int TotalFiles { get; set; }

    public int TotalIssues { get; set; }

    public List<Issue> Issues { get; } = new();
}