namespace CodeInspector.Project.Helpers;

public static class GeneratedFileHelper
{
    public static bool IsGenerated(string path)
    {
        return path.Contains(@"\bin\") ||
               path.Contains(@"\obj\") ||
               path.EndsWith(".Designer.cs", StringComparison.OrdinalIgnoreCase) ||
               path.EndsWith(".g.cs", StringComparison.OrdinalIgnoreCase) ||
               path.EndsWith(".AssemblyInfo.cs", StringComparison.OrdinalIgnoreCase);
    }
}