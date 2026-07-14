using CodeInspector.Fix.Rewriters;
using Microsoft.CodeAnalysis.CSharp;

namespace CodeInspector.Fix.Helpers;

public static class SyntaxTreeFixer
{
    public static string ApplyThrowExFix(string code)
    {
        var tree =
            CSharpSyntaxTree.ParseText(code);

        var root =
            tree.GetRoot();

        var rewriter =
            new ThrowExRewriter();

        var newRoot =
            rewriter.Visit(root);

        return newRoot!.ToFullString();
    }
}