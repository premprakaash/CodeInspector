using System.Collections.Generic;

namespace CodeInspector.Project.Configuration;

public class ConfigurationStore
{
    public List<ConfigurationFile> Files { get; } = new();

    public Dictionary<string, string> Values { get; }
        = new();

    public bool Contains(string key)
    {
        return Values.ContainsKey(key);
    }

    public string? Get(string key)
    {
        Values.TryGetValue(key, out var value);

        return value;
    }
}