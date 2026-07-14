using CodeInspector.Models;
using CodeInspector.Project.Configuration;
using CodeInspector.Project.CsProj;
using CodeInspector.Project.Models;

namespace CodeInspector.Core.Results;

public class AnalysisResult
{
    public ProjectContext Project { get; set; } = new();

    public ConfigurationStore Configuration { get; set; } = new();

    public List<CsProjInfo> Projects { get; } = new();

    public List<Issue> Issues { get; } = new();
}