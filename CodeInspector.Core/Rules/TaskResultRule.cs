using CodeInspector.Core.Context;
using CodeInspector.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeInspector.Core.Rules;

public class TaskResultRule : ICodeRule
{
    public IEnumerable<Issue> Analyze(SyntaxContext context)
    {
        var issues = new List<Issue>();

        foreach (var methodContext in context.MethodContexts)
        {
            foreach (var invocation in methodContext.Invocations)
            {
                // Detect .Wait()
                if (invocation.Expression is MemberAccessExpressionSyntax waitMember)
                {
                    if (waitMember.Name.Identifier.Text == "Wait")
                    {
                        issues.Add(CreateIssue(
                            context,
                            methodContext,
                            invocation,
                            "CI0006",
                            "Avoid Task.Wait",
                            "Task.Wait() blocks the calling thread.",
                            "Use await instead of Task.Wait()."));

                        continue;
                    }
                }
            }

            // Detect .Result
            foreach (var memberAccess in methodContext.Method
                         .DescendantNodes()
                         .OfType<MemberAccessExpressionSyntax>())
            {
                if (memberAccess.Name.Identifier.Text != "Result")
                    continue;

                issues.Add(CreateIssue(
                    context,
                    methodContext,
                    memberAccess,
                    "CI0006",
                    "Avoid Task.Result",
                    "Task.Result blocks the calling thread and may cause deadlocks.",
                    "Use await instead of Task.Result."));
            }
        }

        return issues;
    }

    private static Issue CreateIssue(
        SyntaxContext context,
        MethodContext methodContext,
        SyntaxNode node,
        string ruleId,
        string ruleName,
        string message,
        string recommendation)
    {
        return new Issue
        {
            FileName = context.FileName,
            ClassName = methodContext.Class?.Identifier.Text ?? "",
            MethodName = methodContext.Method.Identifier.Text,
            LineNumber = node.GetLocation()
                             .GetLineSpan()
                             .StartLinePosition.Line + 1,

            RuleId = ruleId,
            RuleName = ruleName,
            RuleType = RuleType.Performance,
            Severity = Severity.High,
            Message = message,
            Recommendation = recommendation
        };
    }
}