using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Services.Config;
using XMinecraftSuite.Core.Services.Download;

namespace XMinecraftSuite.Gui.ViewModels;

public partial class DownloadManagerViewModel : ObservableObject
{
#pragma warning disable CS8618
    public DownloadManagerViewModel(IDownloadService.DownloadServiceFactory serviceFactory, ConfigService coreSettings)
#pragma warning restore CS8618
    {
        this.serviceFactory = serviceFactory;
        CoreSettings = coreSettings.GetConfig<CoreSettings>();
    }

    public CoreSettings CoreSettings { get; set; }

    public ObservableCollection<DownloadTask> DownloadTasks => ServiceFactory(CoreSettings.DownloadService)
        .Tasks;

    [NotifyPropertyChangedFor(nameof(DownloadService))]
    [ObservableProperty]
    private IDownloadService.DownloadServiceFactory serviceFactory;

    [NotifyPropertyChangedFor(nameof(DownloadTasks))]
    [ObservableProperty]
    private IDownloadService downloadService;
}
