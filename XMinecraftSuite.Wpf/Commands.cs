using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using XMinecraftSuite.Wpf.Views;

namespace XMinecraftSuite.Wpf
{
    public class Commands
    {
        #region æ≤Ã¨ Ù–‘
        public static readonly RelayCommand<string> DownloadModFileDialogCommand =
            new(
            (parameter) =>
            {
                if (parameter != null)
                {
                    var window = new ModVersionsListWindow(parameter);
                    window.ShowDialog();
                }
            });
        public static readonly RelayCommand<string> OpenUrlCommand =
            new(
            (url) =>
            {
                if (url != null)
                {
                    Process.Start(new ProcessStartInfo("explorer.exe", url));
                }
            });
        public static readonly RelayCommand<object> QuitCommand =
            new((_) => Environment.Exit(0));
        #endregion
    }
}
