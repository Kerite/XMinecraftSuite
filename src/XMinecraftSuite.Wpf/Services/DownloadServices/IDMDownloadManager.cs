// Copyright (c) Keriteal. All rights reserved.

using System.Collections.ObjectModel;
using IDManLib;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Models.Download;
using XMinecraftSuite.Core.Services.Config;
using XMinecraftSuite.Core.Services.Download;

namespace XMinecraftSuite.Wpf.Services.DownloadServices;

public class IDMDownloadManager : IDownloadService
{
    public IDMDownloadManager(ConfigService options)
    {
        AppSettings = options.GetConfig<CoreSettings>();
    }

    public CoreSettings AppSettings { get; set; }

    public string ServiceName => "idm";

    public ObservableCollection<DownloadTask> Tasks { get; } = new();

    public void Download(DownloadTaskInfo taskInfo)
    {
        new CIDMLinkTransmitterClass().SendLinkToIDM(
            taskInfo.Url,
            null,
            taskInfo.Cookies,
            string.Empty,
            string.Empty,
            string.Empty,
            taskInfo.Path?.Directory!.FullName,
            taskInfo.Path?.Name,
            1);
        throw new NotImplementedException();
    }

    public void Cancel(DownloadTaskInfo taskInfo) => throw new NotImplementedException();
}
