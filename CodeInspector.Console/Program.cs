using CodeInspector.Core.Configuration;
using CodeInspector.Core.Engine;

RuleConfigurationManager.Current =
    ConfigurationLoader.Load("rules.json");

var engine = new AnalysisEngine();

engine.Analyze(
    @"C:\Users\Prem\Downloads\CodeInspectorTestSolution");

Console.ReadLine();