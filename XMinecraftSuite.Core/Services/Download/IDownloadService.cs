using System.Collections.ObjectModel;
using XMinecraftSuite.Core.Models;

namespace XMinecraftSuite.Core.Services.Download;

public interface IDownloadService
{
    delegate void DownloadProgressHandler(DownloadTask download, double percent);

    delegate IDownloadService DownloadServiceFactory(string key);

    public string ServiceName { get; }
    public ObservableCollection<DownloadTask> Tasks { get; }

    public event DownloadProgressHandler OnProgress;

    public void Download(DownloadTask task);
    public void Cancel();
}
