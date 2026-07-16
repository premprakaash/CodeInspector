namespace CodeInspector.Data.Entities;

public class Issue
{
    public Guid Id { get; set; }

    public Guid ScanId { get; set; }

    public string RuleId { get; set; } = "";

    public string RuleName { get; set; } = "";

    public string Severity { get; set; } = "";

    public string FileName { get; set; } = "";

    public string ClassName { get; set; } = "";

    public string MethodName { get; set; } = "";

    public int LineNumber { get; set; }

    public string Message { get; set; } = "";

    public string Recommendation { get; set; } = "";

    public Scan Scan { get; set; } = null!;
}