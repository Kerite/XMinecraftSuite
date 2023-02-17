using System.Text.Json;
using System.Text.Json.Nodes;
using CommunityToolkit.Diagnostics;
using XMinecraftSuite.Core.Models.Configs;

namespace XMinecraftSuite.Core.Services.Config;

public class ConfigServiceBuilder
{
    public ConfigServiceBuilder(string filename)
    {
        Filename = filename;
    }

    private List<Type> Types { get; } = new();
    private string Filename { get; }

    public ConfigServiceBuilder RegisterConfig<T>() where T : class
    {
        Types.Add(typeof(T));
        return this;
    }

    public ConfigServiceBuilder RegisterConfig(Type type)
    {
        Types.Add(type);
        return this;
    }

    public ConfigService Build()
    {
        var configs = new Dictionary<Type, object>();
        var fileContent = File.Exists(Filename) ? File.ReadAllText(Filename) : "{}";
        JsonNode? jsonNode = null;
        try
        {
            jsonNode = JsonNode.Parse(fileContent);
            Guard.IsNotNull(jsonNode);
        }
        catch
        {
            // ignored
        }

        foreach (var type in Types)
        {
            // Check Type is Config
            var attribute = (ConfigAttribute?)Attribute.GetCustomAttribute(type, typeof(ConfigAttribute));
            Guard.IsNotNull(attribute, nameof(attribute));
            if (jsonNode?[attribute.ConfigName] is not null)
            {
                var serialized = JsonSerializer.Deserialize(jsonNode[attribute.ConfigName]!.ToJsonString(), type);
                Guard.IsNotNull(serialized, nameof(serialized));
                configs[type] = serialized;
            }
            else
            {
                var settingObject = Activator.CreateInstance(type);
                Guard.IsNotNull(settingObject, nameof(settingObject));
                configs[type] = settingObject;
            }
        }

        var jsonSerializeOption = new JsonSerializerOptions { WriteIndented = true };

        // Always Recreate Json File
        var jsonText = JsonSerializer.Serialize(configs.ToDictionary(k => k.Key.GetConfigKey(), v => v.Value),
            jsonSerializeOption);
        File.WriteAllText(Filename, jsonText);

        return new ConfigService(configs);
    }
}
