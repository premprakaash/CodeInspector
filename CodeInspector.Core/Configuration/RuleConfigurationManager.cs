namespace CodeInspector.Core.Configuration;

public static class RuleConfigurationManager
{
    public static RuleConfiguration Current { get; set; }
        = new RuleConfiguration();
}