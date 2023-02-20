using System.Collections.ObjectModel;
using XMinecraftSuite.Core.Models.Download;

namespace XMinecraftSuite.Core.Services.Download;

public interface IDownloadService
{
    public ObservableCollection<DownloadTask> Tasks { get; }
    public string ServiceName { get; }

    public void Download(DownloadTask task);
    public void Cancel(DownloadTask task);
}
