using System;

namespace CodeInspector.Project.Models;

public class ProjectFile
{
    public string Name { get; set; } = "";

    public string FullPath { get; set; } = "";

    public string RelativePath { get; set; } = "";

    public string Extension { get; set; } = "";

    public long Size { get; set; }

    public DateTime LastModified { get; set; }
}