using System.Collections.ObjectModel;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Models.Download;
using XMinecraftSuite.Core.Services.Config;

namespace XMinecraftSuite.Core.Services.Download;

internal class AriaDownloadService : IDownloadService
{
    public AriaDownloadService(ConfigService configService)
    {
        AppSettings = configService.GetConfig<CoreSettings>();
        MRequestHelper = new AriaRequestHelper(AppSettings.Aria2JsonRpc, AppSettings.Aria2Secret);
    }

    public string ServiceName => "aria";

    private CoreSettings AppSettings { get; }

    private AriaRequestHelper MRequestHelper { get; }

    public ObservableCollection<DownloadTask> Tasks { get; set; } = new();

    public void Download(DownloadTaskInfo task)
    {
        throw new NotImplementedException();
    }

    public void Cancel(DownloadTaskInfo task)
    {
        throw new NotImplementedException();
    }
}
