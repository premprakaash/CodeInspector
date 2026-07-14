namespace CodeInspector.Fix.Helpers;

public static class SyntaxHelper
{
    public static string Normalize(string code)
    {
        return code.Replace("\r", "")
                   .Trim();
    }
}