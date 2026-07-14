using CodeInspector.Models;
using CodeInspector.Project.Configuration;

namespace CodeInspector.Project.Rules;

public class InvalidJsonRule : IConfigurationRule
{
    public IEnumerable<Issue> Analyze(ConfigurationStore store)
    {
        var issues = new List<Issue>();

        foreach (var file in store.Files)
        {
            if (file.IsValidJson)
                continue;

            issues.Add(new Issue
            {
                RuleId = "CI0101",
                RuleName = "Invalid JSON",
                RuleType = RuleType.Configuration,
                Severity = Severity.Critical,

                FileName = file.FullPath,

                Message =
                    file.ErrorMessage ?? "Invalid JSON.",

                Recommendation =
                    "Correct the JSON syntax."
            });
        }

        return issues;
    }
}