using CodeInspector.Core.Context;
using CodeInspector.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeInspector.Core.Rules;

public class ThrowExRule : ICodeRule
{
    public IEnumerable<Issue> Analyze(SyntaxContext context)
    {
        var issues = new List<Issue>();

        foreach (var methodContext in context.MethodContexts)
        {
            foreach (var tryStatement in methodContext.TryStatements)
            {
                foreach (var catchClause in tryStatement.Catches)
                {
                    var throwStatements = catchClause.DescendantNodes()
                        .OfType<ThrowStatementSyntax>();

                    foreach (var throwStatement in throwStatements)
                    {
                        // Ignore "throw;"
                        if (throwStatement.Expression == null)
                            continue;

                        // Detect "throw ex;"
                        if (throwStatement.Expression is IdentifierNameSyntax)
                        {
                            issues.Add(new Issue
                            {
                                FileName = context.FileName,
                                ClassName = methodContext.Class?.Identifier.Text ?? "",
                                MethodName = methodContext.Method.Identifier.Text,
                                LineNumber = throwStatement.GetLocation()
                                    .GetLineSpan()
                                    .StartLinePosition.Line + 1,

                                RuleId = "CI0004",
                                RuleName = "Use throw instead of throw ex",

                                RuleType = RuleType.Reliability,

                                Severity = Severity.High,

                                Message = "Using 'throw ex;' resets the original stack trace.",

                                Recommendation = "Replace 'throw ex;' with 'throw;' to preserve the original stack trace."
                            });
                        }
                    }
                }
            }
        }

        return issues;
    }
}