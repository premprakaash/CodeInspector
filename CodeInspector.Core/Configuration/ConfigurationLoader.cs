using System.Text.Json;

namespace CodeInspector.Core.Configuration;

public static class ConfigurationLoader
{
    public static RuleConfiguration Load(string file)
    {
        if (!File.Exists(file))
            throw new FileNotFoundException(file);

        var json = File.ReadAllText(file);

        return JsonSerializer.Deserialize<RuleConfiguration>(json)
               ?? new RuleConfiguration();
    }
}