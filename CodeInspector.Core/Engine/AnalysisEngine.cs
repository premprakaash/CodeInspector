using CodeInspector.Core.Context;
using CodeInspector.Core.Results;
using CodeInspector.Core.Rules;
using CodeInspector.Core.Scanner;
using CodeInspector.Project.Configuration;
using CodeInspector.Project.CsProj;
using CodeInspector.Project.Rules;
using CodeInspector.Project.Scanner;

namespace CodeInspector.Core.Engine;

public class AnalysisEngine
{
    public AnalysisResult Analyze(string folder)
    {
        var result = new AnalysisResult();

        //---------------------------------------
        // Project Scan
        //---------------------------------------

        var projectScanner = new ProjectScanner();

        result.Project = projectScanner.Scan(folder);

        //---------------------------------------
        // Configuration Scan
        //---------------------------------------

        var configScanner = new ConfigurationScanner();

        result.Configuration =
            configScanner.Scan(result.Project);

        //---------------------------------------
        // Configuration Rules
        //---------------------------------------

        var configRuleEngine =
            new ConfigurationRuleEngine();

        configRuleEngine.Register(
            new InvalidJsonRule());

        configRuleEngine.Register(
            new EmptyConfigurationValueRule());

        result.Issues.AddRange(
            configRuleEngine.Execute(result.Configuration));

        //---------------------------------------
        // Code Analysis
        //---------------------------------------

        var parser = new CodeParser();

        var builder = new ContextBuilder();

        var ruleEngine = new RuleEngine();

        ruleEngine.Register(new MissingTryCatchRule());
        ruleEngine.Register(new EmptyCatchRule());
        ruleEngine.Register(new MissingLoggerRule());
        ruleEngine.Register(new ThrowExRule());
        ruleEngine.Register(new ThreadSleepRule());
        ruleEngine.Register(new TaskResultRule());
        ruleEngine.Register(new LongMethodRule());
        ruleEngine.Register(new HardcodedPasswordRule());

        foreach (var file in result.Project.CsFiles)
        {
            var tree = parser.Parse(file.FullPath);

            var context = builder.Build(
                file.FullPath,
                tree);

            result.Issues.AddRange(
                ruleEngine.Execute(context));
        }

        //---------------------------------------
        // CSProj Scan
        //---------------------------------------

        var csprojScanner =
            new CsProjScanner();

        foreach (var file in result.Project.CsProjFiles)
        {
            result.Projects.Add(
                csprojScanner.Scan(file.FullPath));
        }

        return result;
    }
}