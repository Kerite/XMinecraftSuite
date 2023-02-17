using CommunityToolkit.Mvvm.ComponentModel;
using XMinecraftSuite.Core.Services.Download;

namespace XMinecraftSuite.Gui.ViewModels;

public class DownloadManagerViewModel : ObservableObject
{
    public IDownloadService.DownloadServiceFactory ServiceFactory { get; set; }

    public DownloadManagerViewModel(IDownloadService.DownloadServiceFactory serviceFactory)
    {
        ServiceFactory = serviceFactory;
    }
}
