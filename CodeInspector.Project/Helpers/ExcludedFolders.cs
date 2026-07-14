namespace CodeInspector.Project.Helpers;

public static class ExcludedFolders
{
    public static readonly HashSet<string> Names =
    [
        "bin",
        "obj",
        ".git",
        ".vs",
        "node_modules",
        "packages",
        "TestResults",
        ".idea",
        ".vscode",
        "publish",
        "artifacts"
    ];

    public static bool IsExcluded(string folderName)
    {
        return Names.Contains(folderName);
    }
}