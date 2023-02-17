using System.Collections.ObjectModel;
using IDManLib;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Services.Config;
using XMinecraftSuite.Core.Services.Download;

namespace XMinecraftSuite.Wpf.Services.DownloadServices;

public class IDMDownloadManager : IDownloadService
{
    public event IDownloadService.DownloadProgressHandler? OnProgress;

    public IDMDownloadManager(ConfigService options)
    {
        AppSettings = options.GetConfig<CoreSettings>();
    }

    public CoreSettings AppSettings { get; set; }

    public string ServiceName => "idm";
    public ObservableCollection<DownloadTask> Tasks { get; } = new();

    public void Download(DownloadTask task)
    {
        new CIDMLinkTransmitterClass().SendLinkToIDM(task.Url, null, task.Cookies, "", "", "",
            task.Path?.Directory!.FullName, task.Path?.Name, 1);
        throw new NotImplementedException();
    }

    public void Cancel()
    {
        throw new NotImplementedException();
    }
}
