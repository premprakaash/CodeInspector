using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis.MSBuild;

namespace CodeInspector.Core.Scanner;

public class SolutionScanner
{
    private readonly MSBuildWorkspace _workspace;

    public SolutionScanner()
    {
        if (!MSBuildLocator.IsRegistered)
        {
            MSBuildLocator.RegisterDefaults();
        }

        _workspace = MSBuildWorkspace.Create();
    }

    public async Task ScanAsync(string solutionPath)
    {
        Console.WriteLine("Opening solution...");
        Console.WriteLine();

        var solution = await _workspace.OpenSolutionAsync(solutionPath);

        Console.WriteLine($"Solution : {solution.FilePath}");
        Console.WriteLine();

        foreach (var project in solution.Projects)
        {
            Console.WriteLine($"Project : {project.Name}");

            foreach (var document in project.Documents)
            {
                Console.WriteLine($"   {document.Name}");
            }

            Console.WriteLine();
        }
    }
}