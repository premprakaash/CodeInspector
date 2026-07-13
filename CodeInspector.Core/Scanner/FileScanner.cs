namespace CodeInspector.Core.Scanner;

public class FileScanner
{
    public IEnumerable<string> GetFiles(string root)
    {
        return Directory
            .EnumerateFiles(
                root,
                "*.cs",
                SearchOption.AllDirectories)
            .Where(x =>
                !x.Contains(@"\bin\") &&
                !x.Contains(@"\obj\"));
    }
}