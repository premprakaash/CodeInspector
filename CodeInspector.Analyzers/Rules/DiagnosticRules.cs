using Microsoft.CodeAnalysis;

namespace CodeInspector.Analyzers;

public static class DiagnosticRules
{
    public static readonly DiagnosticDescriptor MissingTryCatch =
        new DiagnosticDescriptor(
            id: "CI0001",
            title: "Missing Try Catch",
            messageFormat: "Method '{0}' should be wrapped inside try-catch.",
            category: "Reliability",
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);
}