// Copyright (c) Keriteal. All rights reserved.

using System.Collections.ObjectModel;
using Downloader;
using XMinecraftSuite.Core.Models.Download;

namespace XMinecraftSuite.Core.Services.Download;

internal class DownloaderDownloadService : IDownloadService
{
    public ObservableCollection<DownloadTask> Tasks { get; } = new();

    public string ServiceName { get; } = "downloader";

    public void Download(DownloadTaskInfo taskInfo)
    {
        var download = DownloadBuilder.New()
            .WithFileName(taskInfo.Path!.Name)
            .WithUrl(taskInfo.Url)
            .WithDirectory(taskInfo.Path.Directory!.FullName)
            .Build();
    }

    public void Cancel(DownloadTaskInfo task)
    {
        throw new NotImplementedException();
    }
}
