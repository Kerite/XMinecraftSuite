namespace XMinecraftSuite.Wpf;

using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using static XMinecraftSuite.Wpf.Views.ModVersionsListWindow;

public static class Commands
{
    public static readonly RelayCommand<string> DownloadModFileDialogCommand = new((parameter) =>
    {
        if (parameter == null) return;
        var window = App.ServiceProvider!.GetRequiredService<ModVersionsListWindowFactory>();
        window(parameter)
            .Show();
    });

    public static readonly RelayCommand<string> OpenUrlCommand = new((url) =>
    {
        if (url == null) return;

        Process.Start(new ProcessStartInfo("explorer.exe", url));
    });

    public static readonly RelayCommand<object> QuitCommand = new((_) => Environment.Exit(0));
}
