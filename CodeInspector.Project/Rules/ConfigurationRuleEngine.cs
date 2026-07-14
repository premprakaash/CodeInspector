using CodeInspector.Models;
using CodeInspector.Project.Configuration;

namespace CodeInspector.Project.Rules;

public class ConfigurationRuleEngine
{
    private readonly List<IConfigurationRule> _rules = new();

    public void Register(IConfigurationRule rule)
    {
        _rules.Add(rule);
    }

    public List<Issue> Execute(ConfigurationStore store)
    {
        var issues = new List<Issue>();

        foreach (var rule in _rules)
        {
            issues.AddRange(rule.Analyze(store));
        }

        return issues;
    }
}