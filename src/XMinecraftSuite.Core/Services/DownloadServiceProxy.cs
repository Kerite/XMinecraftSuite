// Copyright (c) Keriteal. All rights reserved.

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

    public void Cancel(DownloadTaskInfo task)
    {
        throw new NotImplementedException();
    }

    public void Download(DownloadTaskInfo task)
    {
        throw new NotImplementedException();
    }

    private ConfigService ConfigService { get; }
}
