using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Immutable;

namespace CodeInspector.Analyzers.Rules;

// Specify the supported languages explicitly to avoid RS1038 and RS1041 issues
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class MissingTryCatchAnalyzer : DiagnosticAnalyzer
{
    public override ImmutableArray<DiagnosticDescriptor>
        SupportedDiagnostics
            => ImmutableArray.Create(
                DiagnosticRules.MissingTryCatch);

    public override void Initialize(
        AnalysisContext context)
    {
        // Ensure the analyzer is configured to enforce extended rules
        context.EnableConcurrentExecution();

        context.ConfigureGeneratedCodeAnalysis(
            GeneratedCodeAnalysisFlags.None);

        context.RegisterSyntaxNodeAction(
            AnalyzeMethod,
            SyntaxKind.MethodDeclaration);
    }

    private static void AnalyzeMethod(
        SyntaxNodeAnalysisContext context)
    {
        var method =
            (MethodDeclarationSyntax)context.Node;

        var hasTry =
            method.DescendantNodes()
                  .OfType<TryStatementSyntax>()
                  .Any();

        if (hasTry)
            return;

        var diagnostic =
            Diagnostic.Create(
                DiagnosticRules.MissingTryCatch,
                method.Identifier.GetLocation(),
                method.Identifier.Text);

        context.ReportDiagnostic(diagnostic);
    }
}