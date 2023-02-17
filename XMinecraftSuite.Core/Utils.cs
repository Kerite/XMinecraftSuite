﻿using Microsoft.Extensions.DependencyInjection;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Services.Download;
using static XMinecraftSuite.Core.Services.Download.IDownloadService;

namespace XMinecraftSuite.Core;

public static class Utils
{
    public static string ToSnakeCase(this string str)
    {
        return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? $"_{x}" : x.ToString()))
            .ToLower();
    }

    public static IServiceCollection InjectCoreServices(this IServiceCollection services)
    {
        // Register Download Services
        services.AddSingleton<IDownloadService, DownloaderDownloadService>();
        services.AddSingleton<IDownloadService, AriaDownloadService>();
        services.AddTransient(p =>
        {
            return new DownloadServiceFactory(key => p.GetRequiredService<IEnumerable<IDownloadService>>()
                .FirstOrDefault(k => k.ServiceName == key)!);
        });
        return services;
    }

    public static string GetConfigKey(this Type type)
    {
        return type.GetCustomAttributes(typeof(ConfigAttribute), true)
            .Cast<ConfigAttribute>()
            .FirstOrDefault()
            ?.ConfigName ?? type.Name;
    }

    public static void StartMinecraft(GameStartParameters parameters) { }
}
