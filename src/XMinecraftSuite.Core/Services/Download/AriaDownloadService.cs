// Copyright (c) Keriteal. All rights reserved.

using System.Collections.ObjectModel;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Models.Download;
using XMinecraftSuite.Core.Services.Config;

namespace XMinecraftSuite.Core.Services.Download;

internal class AriaDownloadService : IDownloadService
{
    public AriaDownloadService(ConfigService configService)
    {
        this.AppSettings = configService.GetConfig<CoreSettings>();
        this.MRequestHelper = new AriaRequestHelper(this.AppSettings.Aria2JsonRpc, this.AppSettings.Aria2Secret);
    }

    public string ServiceName => "aria";

    public ObservableCollection<DownloadTask> Tasks { get; set; } = new();

    private CoreSettings AppSettings { get; }

    private AriaRequestHelper MRequestHelper { get; }

    public void Download(DownloadTaskInfo taskInfo)
    {
        throw new NotImplementedException();
    }

    public void Cancel(DownloadTaskInfo taskInfo)
    {
        throw new NotImplementedException();
    }
}
