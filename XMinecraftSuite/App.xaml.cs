using System;
using System.Diagnostics;
using System.Windows;
using XMinecraftSuite.Wpf.Commons.Commands;
using XMinecraftSuite.Wpf.Windows;

namespace XMinecraftSuite.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DelegateCommand<object> QuitCommand = new((_) => { Environment.Exit(0); });

        public static DelegateCommand<string> OpenUrlCommand = new((url) =>
        {
            Process.Start(new ProcessStartInfo(url));
        });

        public static DelegateCommand<string> DownloadModFileDialogCommand = new((parameter) =>
        {
            var window = new ModFilesListWindow(parameter);
            window.ShowDialog();
        });
    }
}