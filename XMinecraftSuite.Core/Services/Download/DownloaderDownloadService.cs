using System.Collections.ObjectModel;
using Downloader;
using XMinecraftSuite.Core.Models;

namespace XMinecraftSuite.Core.Services.Download;

public class DownloaderDownloadService : IDownloadService
{
    public ObservableCollection<DownloadTask> Tasks { get; } = new();
    public string ServiceName { get; } = "downloader";
    public event IDownloadService.DownloadProgressHandler OnProgress;

    public void Download(DownloadTask task)
    {
        var download = DownloadBuilder.New()
            .WithFileName(task.Path.Name)
            .WithUrl(task.Url)
            .WithDirectory(task.Path.Directory!.FullName)
            .Build();
        download.DownloadProgressChanged += (sender, e) => OnProgress?.Invoke(task, e.ProgressPercentage);
    }

    public void Cancel()
    {
        throw new NotImplementedException();
    }
}
