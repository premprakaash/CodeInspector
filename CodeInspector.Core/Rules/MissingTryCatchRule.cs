using CodeInspector.Core.Context;
using CodeInspector.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeInspector.Core.Rules;

public class MissingTryCatchRule : ICodeRule
{
    public IEnumerable<Issue> Analyze(SyntaxContext context)
    {
        var issues = new List<Issue>();

        foreach (var methodContext in context.MethodContexts)
        {
            // Skip methods that already have try-catch
            if (methodContext.Features.HasTryCatch)
                continue;

            // Ignore simple methods
            if (!RequiresTryCatch(methodContext))
                continue;

            var method = methodContext.Method;

            issues.Add(new Issue
            {
                FileName = context.FileName,
                ClassName = methodContext.Class?.Identifier.Text ?? "",
                MethodName = method.Identifier.Text,
                LineNumber = methodContext.LineNumber,

                RuleId = "CI0001",
                RuleName = "Missing Try Catch",

                RuleType = RuleType.Reliability,
                Severity = Severity.High,

                Message = "Method performs risky operations but is not wrapped in a try-catch block.",

                Recommendation = "Wrap the method body in a try-catch block and log the exception."
            });
        }

        return issues;
    }
    private static bool RequiresTryCatch(MethodContext context)
    {
        if (context.Features.HasDatabaseCall)
            return true;

        if (context.Features.HasFileOperation)
            return true;

        if (context.Features.HasHttpCall)
            return true;

        return false;
    }
}