// Copyright (c) Keriteal. All rights reserved.

namespace XMinecraftSuite.Core.Models.Configs;

/// <summary>
/// 配置类.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class ConfigAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigAttribute"/> class.
    /// </summary>
    /// <param name="configName">配置项键.</param>
    public ConfigAttribute(string configName)
    {
        this.ConfigName = configName;
    }

    /// <summary>
    /// 配置项键.
    /// </summary>
    public string ConfigName { get; }
}
