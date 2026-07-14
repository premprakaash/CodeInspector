using CodeInspector.Core.Context;
using CodeInspector.Fix.Models;
using CodeInspector.Models;

namespace CodeInspector.Fix.Interfaces;

public interface ICodeFixProvider
{
    string RuleId { get; }

    FixResult Generate(Issue issue, MethodContext context);
}