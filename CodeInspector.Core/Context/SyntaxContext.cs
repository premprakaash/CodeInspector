using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeInspector.Core.Context;

public class SyntaxContext
{
    public string FileName { get; set; } = "";

    public SyntaxNode Root { get; set; } = default!;

    public List<ClassDeclarationSyntax> Classes { get; } = new();

    public List<MethodDeclarationSyntax> Methods { get; } = new();

    public List<TryStatementSyntax> TryStatements { get; } = new();

    public List<CatchClauseSyntax> CatchClauses { get; } = new();

    public List<InvocationExpressionSyntax> Invocations { get; } = new();
    public List<MethodContext> MethodContexts { get; } = new();

    public Compilation Compilation { get; set; }

    public SemanticModel SemanticModel { get; set; }
}