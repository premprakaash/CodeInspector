using CodeInspector.Core.Features;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeInspector.Core.Context;

public class MethodContext
{
    public MethodDeclarationSyntax Method { get; set; } = default!;

    public ClassDeclarationSyntax? Class { get; set; }

    public List<InvocationExpressionSyntax> Invocations { get; } = new();

    public List<TryStatementSyntax> TryStatements { get; } = new();

    public bool HasTryCatch { get; set; }

    public int LineNumber { get; set; }

    public MethodFeatures Features { get; }
    = new MethodFeatures();

    public int StatementCount { get; set; }

    public int MethodLength { get; set; }
}