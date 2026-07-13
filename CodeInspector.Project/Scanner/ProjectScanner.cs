using CodeInspector.Project.Models;
using System;
using System.IO;

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

        var files = Directory.GetFiles(
            rootFolder,
            "*.*",
            SearchOption.AllDirectories);

        foreach (var file in files)
        {
            var info = new FileInfo(file);

            var projectFile = new ProjectFile
            {
                Name = info.Name,
                FullPath = info.FullName,
                RelativePath = Path.GetRelativePath(rootFolder, file),
                Extension = info.Extension.ToLower(),
                Size = info.Length,
                LastModified = info.LastWriteTime
            };

            context.Files.Add(projectFile);

            Categorize(projectFile, context);
        }

        return context;
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

        if (file.Name.Equals("Dockerfile",
                StringComparison.OrdinalIgnoreCase))
        {
            context.DockerFiles.Add(file);
        }
    }
}