// Copyright (c) Keriteal. All rights reserved.

using System.Text.Json;
using System.Text.Json.Nodes;
using CommunityToolkit.Diagnostics;
using XMinecraftSuite.Core.Models.Configs;

namespace XMinecraftSuite.Core.Services.Config;

/// <summary>
/// 配置服务Builder.
/// </summary>
public class ConfigServiceBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigServiceBuilder"/> class.
    /// </summary>
    /// <param name="filename">配置文件的位置.</param>
    public ConfigServiceBuilder(string filename)
    {
        this.Filename = filename;
    }

    private List<Type> Types { get; } = new();

    private string Filename { get; }

    /// <summary>
    /// 注册配置类.
    /// </summary>
    /// <typeparam name="T">配置类的类型.</typeparam>
    /// <returns>Builder.</returns>
    public ConfigServiceBuilder RegisterConfig<T>()
        where T : class
    {
        this.Types.Add(typeof(T));
        return this;
    }

    /// <summary>
    /// 注册配置类.
    /// </summary>
    /// <param name="type">配置类的类型.</param>
    /// <returns>Builder.</returns>
    public ConfigServiceBuilder RegisterConfig(Type type)
    {
        this.Types.Add(type);
        return this;
    }

    /// <summary>
    /// 构建.
    /// </summary>
    /// <returns>构建的 Service.</returns>
    public ConfigService Build()
    {
        var configs = new Dictionary<Type, object>();
        var fileContent = File.Exists(this.Filename) ? File.ReadAllText(this.Filename) : "{}";
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

        foreach (var type in this.Types)
        {
            // Check Type is Config
            var attribute = (ConfigAttribute?)Attribute.GetCustomAttribute(type, typeof(ConfigAttribute));
            Guard.IsNotNull(attribute);
            if (jsonNode?[attribute.ConfigName] is not null)
            {
                var serialized = JsonSerializer.Deserialize(jsonNode[attribute.ConfigName]!.ToJsonString(), type);
                Guard.IsNotNull(serialized);
                configs[type] = serialized;
            }
            else
            {
                var settingObject = Activator.CreateInstance(type);
                Guard.IsNotNull(settingObject);
                configs[type] = settingObject;
            }
        }

        var jsonSerializeOption = new JsonSerializerOptions { WriteIndented = true };

        // Always Recreate Json File
        var jsonText = JsonSerializer.Serialize(
            configs.ToDictionary(k => k.Key.GetConfigKey(), v => v.Value),
            jsonSerializeOption);
        File.WriteAllText(this.Filename, jsonText);

        return new ConfigService(configs);
    }
}
