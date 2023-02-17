using System.Collections.ObjectModel;
using IDManLib;
using Microsoft.Extensions.Options;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Services.Download;

namespace XMinecraftSuite.Wpf.Services.DownloadServices;

public class IDMDownloadManager : IDownloadService
{
    public event IDownloadService.DownloadProgressHandler? OnProgress;

    public IDMDownloadManager(ICoreSettings options)
    {
        AppSettings = options;
    }

    public ICoreSettings AppSettings { get; set; }

    public string ServiceName => "idm";
    public ObservableCollection<DownloadTask> Tasks { get; } = new();

    public void Download(DownloadTask task)
    {
        new CIDMLinkTransmitterClass().SendLinkToIDM(task.Url, null, task.Cookies, "", "", "",
            task.Path.Directory!.FullName, task.Path.Name, 1);
        throw new NotImplementedException();
    }

    public void Cancel()
    {
        throw new NotImplementedException();
    }
}
