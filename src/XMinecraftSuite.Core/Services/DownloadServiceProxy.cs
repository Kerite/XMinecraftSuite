using System.Collections.ObjectModel;
using XMinecraftSuite.Core.Models.Download;
using XMinecraftSuite.Core.Services.Config;
using XMinecraftSuite.Core.Services.Download;

namespace XMinecraftSuite.Core.Services;

public class DownloadServiceProxy : IDownloadService
{
    public string ServiceName => "proxy";
    public ObservableCollection<DownloadTask> Tasks => throw new NotImplementedException();

    public DownloadServiceProxy(ConfigService configService)
    {
        ConfigService = configService;
    }

    #region 方法 Methods
    public void Cancel(DownloadTask task)
    {
        throw new NotImplementedException();
    }

    public void Download(DownloadTask task)
    {
        throw new NotImplementedException();
    }
    #endregion

    private ConfigService ConfigService { get; }
}
