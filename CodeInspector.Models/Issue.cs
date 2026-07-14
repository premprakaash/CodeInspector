

namespace CodeInspector.Models;

public class Issue
{
    public string FileName { get; set; } = "";

    public string ClassName { get; set; } = "";

    public string MethodName { get; set; } = "";

    public int LineNumber { get; set; }

    public string RuleId { get; set; } = "";

    public string RuleName { get; set; } = "";

    public RuleType RuleType { get; set; }

    public Severity Severity { get; set; }

    public string Message { get; set; } = "";

    public string Recommendation { get; set; } = "";
    public CodeFix? Fix { get; set; }

   
}