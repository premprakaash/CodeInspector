using CodeInspector.Project.Models;
using System;
using System.IO;
using System.Text.Json;

namespace CodeInspector.Project.Configuration;

public class ConfigurationScanner
{
    public ConfigurationStore Scan(ProjectContext context)
    {
        var store = new ConfigurationStore();

        foreach (var file in context.JsonFiles)
        {
            if (!file.Name.StartsWith("appsettings",
                StringComparison.OrdinalIgnoreCase))
                continue;

            ScanJson(file, store);
        }

        return store;
    }

    private void ScanJson(
        ProjectFile file,
        ConfigurationStore store)
    {
        var config = new ConfigurationFile
        {
            FileName = file.Name,
            FullPath = file.FullPath
        };

        try
        {
            var json = File.ReadAllText(file.FullPath);

            using var document =
                JsonDocument.Parse(json);

            config.IsValidJson = true;

            ReadObject(
                document.RootElement,
                "",
                store);
        }
        catch (Exception ex)
        {
            config.IsValidJson = false;
            config.ErrorMessage = ex.Message;
        }

        store.Files.Add(config);
    }

    private void ReadObject(
        JsonElement element,
        string prefix,
        ConfigurationStore store)
    {
        foreach (var property in element.EnumerateObject())
        {
            var key = string.IsNullOrEmpty(prefix)
                ? property.Name
                : $"{prefix}:{property.Name}";

            if (property.Value.ValueKind ==
                JsonValueKind.Object)
            {
                ReadObject(
                    property.Value,
                    key,
                    store);
            }
            else
            {
                store.Values[key] =
                    property.Value.ToString();
            }
        }
    }
}