// Copyright (c) Keriteal. All rights reserved.

using Microsoft.Extensions.DependencyInjection;
using SkiaSharp;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Services;
using XMinecraftSuite.Core.Services.Download;

namespace XMinecraftSuite.Core;

/// <summary>
/// 工具类.
/// </summary>
public static class Utils
{
    /// <summary>
    /// 转换字符串为snake_case.
    /// </summary>
    /// <param name="str">输入字符串.</param>
    /// <returns>被转换为 snake_case 的字符串.</returns>
    public static string ToSnakeCase(this string str)
    {
        return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? $"_{x}" : x.ToString()))
            .ToLower();
    }

    /// <summary>
    /// 注入核心的服务.
    /// </summary>
    /// <param name="services">要注入的服务集合.</param>
    /// <returns>同一个服务集合.</returns>
    public static IServiceCollection InjectCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<IDownloadService, AriaDownloadService>();
        services.AddSingleton<IDownloadService, DownloaderDownloadService>();
        services.AddSingleton<IDownloadService, DownloadServiceProxy>();
        return services;
    }

    /// <summary>
    /// 获取配置类的标识符.
    /// </summary>
    /// <param name="type">配置类.</param>
    /// <returns>配置类的标识符.</returns>
    public static string GetConfigKey(this Type type)
    {
        return type.GetCustomAttributes(typeof(ConfigAttribute), true)
            .Cast<ConfigAttribute>()
            .FirstOrDefault()
            ?.ConfigName ?? type.Name;
    }

    /// <summary>
    /// 启动游戏.
    /// </summary>
    /// <param name="parameters">启动参数.</param>
    public static void StartMinecraft(RunGameParameters parameters)
    {
        // Method intentionally left empty.
    }

    /// <summary>
    /// 加载图片.
    /// </summary>
    /// <param name="bytes">图片的字节.</param>
    /// <returns>位图.</returns>
    public static SKBitmap LoadBitmap(byte[] bytes)
    {
        return SKBitmap.Decode(bytes);
    }
}
