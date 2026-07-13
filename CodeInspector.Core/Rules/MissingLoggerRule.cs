using CodeInspector.Core.Context;
using CodeInspector.Models;

namespace CodeInspector.Core.Rules;

public class MissingLoggerRule : ICodeRule
{
    public IEnumerable<Issue> Analyze(SyntaxContext context)
    {
        var issues = new List<Issue>();

        foreach (var methodContext in context.MethodContexts)
        {
            // Rule only applies to methods that have a try-catch
            if (!methodContext.Features.HasTryCatch)
                continue;

            // If logging exists, no issue
            if (methodContext.Features.HasLogger)
                continue;

            issues.Add(new Issue
            {
                FileName = context.FileName,
                ClassName = methodContext.Class?.Identifier.Text ?? "",
                MethodName = methodContext.Method.Identifier.Text,
                LineNumber = methodContext.LineNumber,

                RuleId = "CI0003",
                RuleName = "Missing Logger",

                RuleType = RuleType.Logging,

                Severity = Severity.High,

                Message = "Exception is caught but no logging statement was found.",

                Recommendation = "Log the exception using ILogger or Serilog before rethrowing or handling it."
            });
        }

        return issues;
    }
}