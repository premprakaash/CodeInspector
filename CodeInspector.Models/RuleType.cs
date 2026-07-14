namespace CodeInspector.Models;

public enum RuleType
{
    // Code Analysis
    Reliability,
    Security,
    Performance,
    Architecture,
    Logging,
    Async,
    Naming,
    Style,

    // Project Analysis
    Configuration,
    Project,
    Solution,
    NuGet,
    Docker,
    Kubernetes,
    SQL,
    Documentation,

    // Future
    Dependency,
    Testing,
    Cloud,
    DevOps,
    AI,
    Microservice
}