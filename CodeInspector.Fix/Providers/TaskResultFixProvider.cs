using CodeInspector.Core.Context;
using CodeInspector.Fix.Interfaces;
using CodeInspector.Fix.Models;
using CodeInspector.Models;

namespace CodeInspector.Fix.Providers;

public class TaskResultFixProvider : ICodeFixProvider
{
    public string RuleId => "CI0006";

    public FixResult Generate(
        Issue issue,
        MethodContext context)
    {
        return new FixResult
        {
            Success = true,

            RuleId = RuleId,

            OriginalCode = "task.Result",

            FixedCode = "await task",

            Explanation =
                "Await the task instead of blocking with Result.",

            CanAutoFix = true
        };
    }
}