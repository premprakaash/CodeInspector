using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeInspector.Fix.Rewriters;

public class ThrowExRewriter : CSharpSyntaxRewriter
{
    public override SyntaxNode? VisitThrowStatement(
        ThrowStatementSyntax node)
    {
        // ignore "throw;"
        if (node.Expression == null)
            return base.VisitThrowStatement(node);

        // detect "throw ex;"
        if (node.Expression is IdentifierNameSyntax)
        {
            return SyntaxFactory.ThrowStatement()
                .WithLeadingTrivia(node.GetLeadingTrivia())
                .WithTrailingTrivia(node.GetTrailingTrivia());
        }

        return base.VisitThrowStatement(node);
    }
}