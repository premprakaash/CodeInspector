using CodeInspector.Core.Context;
using CodeInspector.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeInspector.Core.Rules;

public class HardcodedPasswordRule : ICodeRule
{
    public IEnumerable<Issue> Analyze(SyntaxContext context)
    {
        var issues = new List<Issue>();

        foreach (var methodContext in context.MethodContexts)
        {
            var variables = methodContext.Method
                .DescendantNodes()
                .OfType<VariableDeclaratorSyntax>();

            foreach (var variable in variables)
            {
                if (variable.Initializer == null)
                    continue;

                var variableName = variable.Identifier.Text.ToLower();

                if (!(variableName.Contains("password") ||
                      variableName.Contains("pwd") ||
                      variableName.Contains("pass")))
                    continue;

                if (variable.Initializer.Value is not LiteralExpressionSyntax literal)
                    continue;

                if (!literal.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.StringLiteralExpression))
                    continue;

                var line = variable.GetLocation()
                    .GetLineSpan()
                    .StartLinePosition.Line + 1;

                issues.Add(new Issue
                {
                    FileName = context.FileName,
                    ClassName = methodContext.Class?.Identifier.Text ?? "",
                    MethodName = methodContext.Method.Identifier.Text,
                    LineNumber = line,

                    RuleId = "CI0008",
                    RuleName = "Hardcoded Password",

                    RuleType = RuleType.Security,

                    Severity = Severity.Critical,

                    Message = "Hardcoded password detected.",

                    Recommendation =
                        "Move the password to configuration, Azure Key Vault, environment variables, or a secrets manager."
                });
            }
        }

        return issues;
    }
}