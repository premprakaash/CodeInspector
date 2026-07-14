using System.Security.Cryptography;

namespace CodeInspector.Project.Helpers;

public static class FileHashService
{
    public static string Calculate(string file)
    {
        using var stream = File.OpenRead(file);

        using var sha = SHA256.Create();

        var hash = sha.ComputeHash(stream);

        return Convert.ToHexString(hash);
    }
}