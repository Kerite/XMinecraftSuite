// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using static XMinecraftSuite.Wpf.Views.ModVersionsListWindow;

namespace XMinecraftSuite.Wpf;

/// <summary>
/// 全局使用的一些命令.
/// </summary>
public static class Commands
{
    /// <summary>
    /// 显示下载Mod文件命令.
    /// </summary>
    public static readonly RelayCommand<string> ShowModVersionsCommand = new((parameter) =>
    {
        if (parameter == null)
        {
            return;
        }

        var window = App.ServiceProvider!.GetRequiredService<ModVersionsListWindowFactory>();
        window(parameter)
            .Show();
    });

    /// <summary>
    /// 打开Url命令.
    /// </summary>
    public static readonly RelayCommand<string> OpenUrlCommand = new((url) =>
    {
        if (url == null)
        {
            return;
        }

        Process.Start(new ProcessStartInfo("explorer.exe", url));
    });

    /// <summary>
    /// 退出应用命令.
    /// </summary>
    public static readonly RelayCommand<object> QuitCommand = new((_) => Environment.Exit(0));
}
