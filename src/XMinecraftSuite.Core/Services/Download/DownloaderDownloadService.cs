using Downloader;
using System.Collections.ObjectModel;
using XMinecraftSuite.Core.Models.Download;

namespace XMinecraftSuite.Core.Services.Download;

internal class DownloaderDownloadService : IDownloadService
{
    public ObservableCollection<DownloadTask> Tasks { get; } = new();
    public string ServiceName { get; } = "downloader";

    public void Download(DownloadTask task)
    {
        var download = DownloadBuilder.New()
            .WithFileName(task.TaskInfo.Path!.Name)
            .WithUrl(task.TaskInfo.Url)
            .WithDirectory(task.TaskInfo.Path.Directory!.FullName)
            .Build();
    }

    public void Cancel(DownloadTask task)
    {
        throw new NotImplementedException();
    }
}
