using CodeInspector.Core.Context;
using CodeInspector.Models;

namespace CodeInspector.Core.Rules;

public class RuleEngine
{
    private readonly List<ICodeRule> _rules = new();

    public void Register(ICodeRule rule)
    {
        _rules.Add(rule);
    }

    public IEnumerable<Issue> Execute(SyntaxContext context)
    {
        var issues = new List<Issue>();

        foreach (var rule in _rules)
        {
            var result = rule.Analyze(context).ToList();

            Console.WriteLine($"{rule.GetType().Name} -> {result.Count}");

            issues.AddRange(result);
        }

        return issues;
    }
}