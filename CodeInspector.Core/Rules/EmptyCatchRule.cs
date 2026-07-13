using CodeInspector.Core.Context;
using CodeInspector.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeInspector.Core.Rules;

public class EmptyCatchRule : ICodeRule
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
                    if (catchClause.Block == null)
                        continue;

                    if (catchClause.Block.Statements.Any())
                        continue;

                    var line = catchClause.GetLocation()
                                          .GetLineSpan()
                                          .StartLinePosition.Line + 1;

                    issues.Add(new Issue
                    {
                        FileName = context.FileName,

                        ClassName = methodContext.Class?.Identifier.Text ?? "",

                        MethodName = methodContext.Method.Identifier.Text,

                        LineNumber = line,

                        RuleId = "CI0002",

                        RuleName = "Empty Catch Block",

                        RuleType = RuleType.Reliability,

                        Severity = Severity.Critical,

                        Message = "Catch block is empty.",

                        Recommendation =
                            "Log the exception and rethrow or handle it appropriately."
                    });
                }
            }
        }

        return issues;
    }
}