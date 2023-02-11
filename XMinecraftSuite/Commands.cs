using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using XMinecraftSuite.Wpf.Windows;

namespace XMinecraftSuite.Wpf;

public class Commands
{
    public readonly static RelayCommand<object> QuitCommand =
        new(
            (_) =>
            {
                Environment.Exit(0);
            }
        );

    public readonly static RelayCommand<string> OpenUrlCommand =
        new(
            (url) =>
            {
                if (url != null)
                {
                    Process.Start(new ProcessStartInfo(url));
                }
            }
        );

    public readonly static RelayCommand<string> DownloadModFileDialogCommand =
        new(
            (parameter) =>
            {
                var window = new ModFilesListWindow(parameter);
                window.ShowDialog();
            }
        );
}