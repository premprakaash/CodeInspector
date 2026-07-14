using CodeInspector.Project.Helpers;
using CodeInspector.Project.Models;

namespace CodeInspector.Project.Scanner;

public class ProjectScanner
{
    public ProjectContext Scan(string rootFolder)
    {
        if (!Directory.Exists(rootFolder))
            throw new DirectoryNotFoundException(rootFolder);

        var context = new ProjectContext
        {
            RootFolder = rootFolder
        };

        ScanDirectory(rootFolder, context);

        return context;
    }

    private void ScanDirectory(
        string folder,
        ProjectContext context)
    {
        var directory = new DirectoryInfo(folder);

        if (ExcludedFolders.IsExcluded(directory.Name))
            return;

        foreach (var file in directory.GetFiles())
        {
            AddFile(file, context);
        }

        foreach (var subDirectory in directory.GetDirectories())
        {
            ScanDirectory(subDirectory.FullName, context);
        }
    }

    private void AddFile(
        FileInfo info,
        ProjectContext context)
    {
        var projectFile = new ProjectFile
        {
            Name = info.Name,
            FullPath = info.FullName,
            RelativePath = Path.GetRelativePath(context.RootFolder, info.FullName),
            Extension = info.Extension.ToLowerInvariant(),
            Size = info.Length,
            LastModified = info.LastWriteTime,

            IsHidden = (info.Attributes & FileAttributes.Hidden) != 0,

            IsGenerated = GeneratedFileHelper.IsGenerated(info.FullName),

            IsTestProject =
                info.FullName.Contains("Test", StringComparison.OrdinalIgnoreCase) ||
                info.FullName.Contains("Tests", StringComparison.OrdinalIgnoreCase),

            Hash = FileHashService.Calculate(info.FullName)
        };

        context.Files.Add(projectFile);

        Categorize(projectFile, context);
    }

    private static void Categorize(
        ProjectFile file,
        ProjectContext context)
    {
        switch (file.Extension)
        {
            case ".cs":
                context.CsFiles.Add(file);
                break;

            case ".json":
                context.JsonFiles.Add(file);
                break;

            case ".config":
                context.ConfigFiles.Add(file);
                break;

            case ".csproj":
                context.CsProjFiles.Add(file);
                break;

            case ".sql":
                context.SqlFiles.Add(file);
                break;

            case ".xml":
                context.XmlFiles.Add(file);
                break;

            case ".yml":
            case ".yaml":
                context.YamlFiles.Add(file);
                break;
        }

        if (file.Name.Equals("Dockerfile", StringComparison.OrdinalIgnoreCase))
        {
            context.DockerFiles.Add(file);
        }
    }
}