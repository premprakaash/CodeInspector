using CodeInspector.Core.Context;
using CodeInspector.Fix.Helpers;
using CodeInspector.Fix.Interfaces;
using CodeInspector.Fix.Models;
using CodeInspector.Models;

namespace CodeInspector.Fix.Providers;

public class ThrowExFixProvider : ICodeFixProvider
{
    public string RuleId => "CI0004";

    public FixResult Generate(
        Issue issue,
        MethodContext context)
    {
        var fixedCode =
    SyntaxTreeFixer.ApplyThrowExFix(
        context.Method.ToFullString());

        return new FixResult
        {
            Success = true,

            RuleId = RuleId,

            OriginalCode =
                context.Method.ToFullString(),

            FixedCode = fixedCode,

            Explanation =
                "throw; preserves the original stack trace.",

            CanAutoFix = true
        };
    }
}