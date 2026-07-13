using CodeInspector.Core.Configuration;
using CodeInspector.Core.Context;
using CodeInspector.Models;

namespace CodeInspector.Core.Rules;

public class LongMethodRule : ICodeRule
{
    public IEnumerable<Issue> Analyze(SyntaxContext context)
    {
        var config = RuleConfigurationManager.Current.LongMethod;

        if (!config.Enabled)
            return Enumerable.Empty<Issue>();

        var maxStatements = config.MaxStatements;
        var maxLines = config.MaxLines;

        var issues = new List<Issue>();

        foreach (var methodContext in context.MethodContexts)
        {
            if (methodContext.StatementCount <= maxStatements &&
                methodContext.MethodLength <= maxLines)
                continue;

            issues.Add(new Issue
            {
                FileName = context.FileName,
                ClassName = methodContext.Class?.Identifier.Text ?? "",
                MethodName = methodContext.Method.Identifier.Text,
                LineNumber = methodContext.LineNumber,

                RuleId = "CI0007",
                RuleName = "Long Method",

                RuleType = RuleType.Architecture,

                Severity = Severity.Medium,

                Message = $"Method contains {methodContext.StatementCount} statements and {methodContext.MethodLength} lines.",

                Recommendation = "Split the method into smaller methods with a single responsibility."
            });
        }

        return issues;
    }
}