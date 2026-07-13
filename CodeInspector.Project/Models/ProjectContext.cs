using System.Collections.Generic;

namespace CodeInspector.Project.Models;

public class ProjectContext
{
    public string RootFolder { get; set; } = "";

    public List<ProjectFile> Files { get; } = new();

    public List<ProjectFile> CsFiles { get; } = new();

    public List<ProjectFile> JsonFiles { get; } = new();

    public List<ProjectFile> ConfigFiles { get; } = new();

    public List<ProjectFile> CsProjFiles { get; } = new();

    public List<ProjectFile> SqlFiles { get; } = new();

    public List<ProjectFile> DockerFiles { get; } = new();

    public List<ProjectFile> YamlFiles { get; } = new();

    public List<ProjectFile> XmlFiles { get; } = new();
}