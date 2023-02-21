// Copyright (c) Keriteal. All rights reserved.

namespace XMinecraftSuite.Core.Services.Config;

/// <summary>
/// 配置服务.
/// </summary>
public class ConfigService
{
    internal ConfigService(Dictionary<Type, object> configs)
    {
        this.Configs = configs;
    }

    private Dictionary<Type, object> Configs { get; }

    /// <summary>
    /// 获取配置.
    /// </summary>
    /// <typeparam name="T">配置类.</typeparam>
    /// <returns>配置.</returns>
    public T GetConfig<T>()
        where T : class
    {
        return (T)this.Configs[typeof(T)];
    }
}
