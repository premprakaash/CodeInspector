using CodeInspector.Core.Context;
using CodeInspector.Fix.Interfaces;
using CodeInspector.Fix.Models;
using CodeInspector.Models;

namespace CodeInspector.Fix.Providers;

public class ThreadSleepFixProvider : ICodeFixProvider
{
    public string RuleId => "CI0005";

    public FixResult Generate(
        Issue issue,
        MethodContext context)
    {
        return new FixResult
        {
            Success = true,

            RuleId = RuleId,

            OriginalCode = "Thread.Sleep(milliseconds);",

            FixedCode = "await Task.Delay(milliseconds);",

            Explanation =
                "Task.Delay is asynchronous and does not block the thread.",

            CanAutoFix = true
        };
    }
}