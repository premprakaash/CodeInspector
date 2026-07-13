using CodeInspector.Core.Context;
using CodeInspector.Models;

namespace CodeInspector.Core.Rules;

public interface ICodeRule
{
    IEnumerable<Issue> Analyze(
        SyntaxContext context);
}