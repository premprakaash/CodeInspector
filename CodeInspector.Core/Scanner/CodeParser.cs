using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CodeInspector.Core.Scanner;

public class CodeParser
{
    public SyntaxTree Parse(string file)
    {
        var code = File.ReadAllText(file);

        return CSharpSyntaxTree.ParseText(code);
    }
}