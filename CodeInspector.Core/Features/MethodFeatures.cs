namespace CodeInspector.Core.Features;

public class MethodFeatures
{
    public bool HasTryCatch { get; set; }

    public bool HasLogger { get; set; }

    public bool HasDatabaseCall { get; set; }

    public bool HasFileOperation { get; set; }

    public bool HasHttpCall { get; set; }

    public bool UsesTaskResult { get; set; }

    public bool UsesThreadSleep { get; set; }

    public bool IsAsync { get; set; }
}