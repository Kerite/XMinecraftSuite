using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Models.Download;
using XMinecraftSuite.Core.Services;
using XMinecraftSuite.Core.Services.Config;
using XMinecraftSuite.Core.Services.Download;

namespace XMinecraftSuite.Gui.ViewModels;

public partial class DownloadManagerViewModel : ObservableObject
{
    public DownloadManagerViewModel(ConfigService coreSettings, DownloadServiceProxy downloadServiceProxy)
    {
        downloadService = downloadServiceProxy;
        CoreSettings = coreSettings.GetConfig<CoreSettings>();
    }

    public CoreSettings CoreSettings { get; set; }

    [ObservableProperty]
    private DownloadServiceProxy downloadService;
}
