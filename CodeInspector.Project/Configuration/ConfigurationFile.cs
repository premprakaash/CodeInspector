namespace CodeInspector.Project.Configuration;

public class ConfigurationFile
{
    public string FileName { get; set; } = "";

    public string FullPath { get; set; } = "";

    public bool IsValidJson { get; set; }

    public string? ErrorMessage { get; set; }
}