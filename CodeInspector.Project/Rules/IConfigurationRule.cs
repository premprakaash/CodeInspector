using CodeInspector.Models;
using CodeInspector.Project.Configuration;

namespace CodeInspector.Project.Rules;

public interface IConfigurationRule
{
    IEnumerable<Issue> Analyze(ConfigurationStore store);
}