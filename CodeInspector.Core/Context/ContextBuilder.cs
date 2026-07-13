using CodeInspector.Core.Features;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeInspector.Core.Context;

public class ContextBuilder
{
    public SyntaxContext Build(
        string fileName,
        SyntaxTree tree)
    {
        var root = tree.GetRoot();

        var context = new SyntaxContext
        {
            FileName = fileName,
            Root = root
        };

        context.Classes.AddRange(
            root.DescendantNodes()
                .OfType<ClassDeclarationSyntax>());

        context.Methods.AddRange(
            root.DescendantNodes()
                .OfType<MethodDeclarationSyntax>());

        context.TryStatements.AddRange(
            root.DescendantNodes()
                .OfType<TryStatementSyntax>());

        context.CatchClauses.AddRange(
            root.DescendantNodes()
                .OfType<CatchClauseSyntax>());

        context.Invocations.AddRange(
            root.DescendantNodes()
                .OfType<InvocationExpressionSyntax>());

        // ⭐ Build Method Contexts
        foreach (var method in context.Methods)
        {
            var methodContext = new MethodContext
            {
                Method = method,
                Class = method.Parent as ClassDeclarationSyntax,
                HasTryCatch = method.DescendantNodes()
                                    .OfType<TryStatementSyntax>()
                                    .Any(),

                LineNumber = method.GetLocation()
                                   .GetLineSpan()
                                   .StartLinePosition.Line + 1
            };

            methodContext.Invocations.AddRange(
                method.DescendantNodes()
                      .OfType<InvocationExpressionSyntax>());

            methodContext.TryStatements.AddRange(
                method.DescendantNodes()
                      .OfType<TryStatementSyntax>());


            methodContext.StatementCount =
    method.DescendantNodes()
          .OfType<StatementSyntax>()
          .Count();

            var span = method.GetLocation().GetLineSpan();

            methodContext.MethodLength =
                span.EndLinePosition.Line -
                span.StartLinePosition.Line + 1;

            var extractor = new FeatureExtractor();

            extractor.Extract(methodContext);

            context.MethodContexts.Add(methodContext);

         
        }

        return context;
    }
}