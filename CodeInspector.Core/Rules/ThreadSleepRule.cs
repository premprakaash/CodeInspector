using CodeInspector.Core.Context;
using CodeInspector.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeInspector.Core.Rules;

public class ThreadSleepRule : ICodeRule
{
    public IEnumerable<Issue> Analyze(SyntaxContext context)
    {
        var issues = new List<Issue>();

        foreach (var methodContext in context.MethodContexts)
        {
            foreach (var invocation in methodContext.Invocations)
            {
                if (!invocation.ToString().Contains("Thread.Sleep"))
                    continue;

                issues.Add(new Issue
                {
                    FileName = context.FileName,
                    ClassName = methodContext.Class?.Identifier.Text ?? "",
                    MethodName = methodContext.Method.Identifier.Text,
                    LineNumber = invocation.GetLocation()
                                           .GetLineSpan()
                                           .StartLinePosition.Line + 1,

                    RuleId = "CI0005",
                    RuleName = "Avoid Thread.Sleep",

                    RuleType = RuleType.Performance,

                    Severity = Severity.Medium,

                    Message = "Thread.Sleep blocks the current thread.",

                    Recommendation = "Use await Task.Delay() in asynchronous code whenever possible."
                });
            }
        }

        return issues;
    }
}