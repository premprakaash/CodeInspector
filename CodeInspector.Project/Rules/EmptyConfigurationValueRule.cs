using CodeInspector.Models;
using CodeInspector.Project.Configuration;

namespace CodeInspector.Project.Rules;

public class EmptyConfigurationValueRule : IConfigurationRule
{
    public IEnumerable<Issue> Analyze(ConfigurationStore store)
    {
        var issues = new List<Issue>();

        foreach (var item in store.Values)
        {
            if (!string.IsNullOrWhiteSpace(item.Value))
                continue;

            issues.Add(new Issue
            {
                RuleId = "CI0102",

                RuleName = "Empty Configuration Value",

                RuleType = RuleType.Configuration,

                Severity = Severity.High,

                FileName = "",

                Message =
                    $"Configuration key '{item.Key}' has an empty value.",

                Recommendation =
                    "Provide a value for this configuration key."
            });
        }

        return issues;
    }
}