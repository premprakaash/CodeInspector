namespace CodeInspector.Core.Configuration;

public class RuleConfiguration
{
    public LongMethodConfiguration LongMethod { get; set; } = new();

    public RuleSettings MissingTryCatch { get; set; } = new();

    public RuleSettings EmptyCatch { get; set; } = new();

    public RuleSettings MissingLogger { get; set; } = new();

    public RuleSettings ThreadSleep { get; set; } = new();

    public RuleSettings TaskResult { get; set; } = new();
}

public class RuleSettings
{
    public bool Enabled { get; set; }

    public string Severity { get; set; } = "";
}

public class LongMethodConfiguration : RuleSettings
{
    public int MaxStatements { get; set; }

    public int MaxLines { get; set; }
}