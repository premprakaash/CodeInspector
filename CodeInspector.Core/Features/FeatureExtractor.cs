using CodeInspector.Core.Context;

namespace CodeInspector.Core.Features;

public class FeatureExtractor
{
    public void Extract(MethodContext context)
    {
        context.Features.HasTryCatch =
            context.TryStatements.Any();

        context.Features.IsAsync =
            context.Method.Modifiers
                   .Any(x => x.Text == "async");

        foreach (var invocation in context.Invocations)
        {
            var text = invocation.ToString();

            DetectLogging(text, context);

            DetectDatabase(text, context);

            DetectFileOperations(text, context);

            DetectHttp(text, context);

            DetectTask(text, context);

            DetectThread(text, context);
        }
    }
    private static void DetectLogging(
    string text,
    MethodContext context)
    {
        if (text.Contains("Log"))
            context.Features.HasLogger = true;

        if (text.Contains("LogError"))
            context.Features.HasLogger = true;

        if (text.Contains("LogInformation"))
            context.Features.HasLogger = true;

        if (text.Contains("LogWarning"))
            context.Features.HasLogger = true;

        if (text.Contains("Serilog"))
            context.Features.HasLogger = true;
    }
    private static void DetectDatabase(
    string text,
    MethodContext context)
    {
        string[] dbCalls =
        {
        "ExecuteReader",
        "ExecuteNonQuery",
        "ExecuteScalar",
        "Fill(",
        "Open(",
        "ExecuteDataset",
        "ExecuteDataSet",
        "ExecuteDataTable"
    };

        if (dbCalls.Any(text.Contains))
            context.Features.HasDatabaseCall = true;
    }
    private static void DetectFileOperations(
    string text,
    MethodContext context)
    {
        string[] fileCalls =
        {
        "ReadAllText",
        "WriteAllText",
        "ReadAllBytes",
        "WriteAllBytes",
        "File.Copy",
        "File.Delete",
        "Directory.CreateDirectory"
    };

        if (fileCalls.Any(text.Contains))
            context.Features.HasFileOperation = true;
    }
    private static void DetectHttp(
    string text,
    MethodContext context)
    {
        string[] httpCalls =
        {
        "GetAsync",
        "PostAsync",
        "PutAsync",
        "DeleteAsync",
        "SendAsync"
    };

        if (httpCalls.Any(text.Contains))
            context.Features.HasHttpCall = true;
    }
    private static void DetectTask(
    string text,
    MethodContext context)
    {
        if (text.Contains(".Result"))
            context.Features.UsesTaskResult = true;
    }
    private static void DetectThread(
    string text,
    MethodContext context)
    {
        if (text.Contains("Thread.Sleep"))
            context.Features.UsesThreadSleep = true;
    }
}