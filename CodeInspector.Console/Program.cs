using CodeInspector.Core.Context;
using CodeInspector.Core.Rules;
using CodeInspector.Core.Scanner;
using CodeInspector.Core.Configuration;
using CodeInspector.Project.Scanner;

RuleConfigurationManager.Current =
    ConfigurationLoader.Load("rules.json");


var parser = new CodeParser();

var engine = new RuleEngine();
engine.Register(new MissingTryCatchRule());
engine.Register(new EmptyCatchRule());
engine.Register(new MissingLoggerRule()); 
engine.Register(new ThreadSleepRule());

// Future
// engine.Register(new EmptyCatchRule());
// engine.Register(new MissingLoggerRule());
// engine.Register(new SqlInjectionRule());
var scanner = new ProjectScanner();

var project = scanner.Scan(
    @"D:\TFS\MBSUjjivan\MBS");

Console.WriteLine("========== PROJECT SUMMARY ==========");

Console.WriteLine($"Total Files : {project.Files.Count}");
Console.WriteLine($"C# Files    : {project.CsFiles.Count}");
Console.WriteLine($"JSON Files  : {project.JsonFiles.Count}");
Console.WriteLine($"Config      : {project.ConfigFiles.Count}");
Console.WriteLine($"CSProj      : {project.CsProjFiles.Count}");
Console.WriteLine($"SQL         : {project.SqlFiles.Count}");
Console.WriteLine($"Docker      : {project.DockerFiles.Count}");
Console.WriteLine($"YAML        : {project.YamlFiles.Count}");
Console.WriteLine($"XML         : {project.XmlFiles.Count}");
