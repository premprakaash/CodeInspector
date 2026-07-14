namespace CodeInspector.Fix.Models;

public class FixResult
{
    public bool Success { get; set; }

    public string RuleId { get; set; } = "";

    public string OriginalCode { get; set; } = "";

    public string FixedCode { get; set; } = "";

    public string Explanation { get; set; } = "";

    public bool CanAutoFix { get; set; }
}