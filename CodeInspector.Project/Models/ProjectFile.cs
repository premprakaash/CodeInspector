namespace CodeInspector.Project.Models;

public class ProjectFile
{
    public string Name { get; set; } = "";

    public string FullPath { get; set; } = "";

    public string RelativePath { get; set; } = "";

    public string Extension { get; set; } = "";

    public long Size { get; set; }

    public DateTime LastModified { get; set; }

    public string Hash { get; set; } = "";

    public bool IsGenerated { get; set; }

    public bool IsTestProject { get; set; }

    public bool IsHidden { get; set; }
}