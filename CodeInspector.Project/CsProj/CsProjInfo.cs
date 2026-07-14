namespace CodeInspector.Project.CsProj;

public class CsProjInfo
{
    public string ProjectName { get; set; } = "";

    public string ProjectPath { get; set; } = "";

    public string TargetFramework { get; set; } = "";

    public string OutputType { get; set; } = "";

    public string LangVersion { get; set; } = "";

    public bool NullableEnabled { get; set; }

    public bool ImplicitUsingsEnabled { get; set; }

    public List<PackageReference> Packages { get; } = new();

    public List<string> ProjectReferences { get; } = new();
}