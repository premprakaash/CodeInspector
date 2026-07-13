using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeInspector.Core.Scanner;

public class MethodScanner
{
    public IEnumerable<MethodDeclarationSyntax> GetMethods(
        SyntaxTree tree)
    {
        var root = tree.GetRoot();

        return root
            .DescendantNodes()
            .OfType<MethodDeclarationSyntax>();
    }
}