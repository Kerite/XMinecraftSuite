// Copyright (c) Keriteal. All rights reserved.

using System.Collections.ObjectModel;
using XMinecraftSuite.Core.Models.Download;

namespace XMinecraftSuite.Core.Services.Download;

/// <summary>
///  下载服务.
/// </summary>
public interface IDownloadService
{
    /// <summary>
    /// Gets 下载列表.
    /// </summary>
    public ObservableCollection<DownloadTask> Tasks { get; }

    /// <summary>
    /// Gets 下载服务的名字.
    /// </summary>
    public string ServiceName { get; }

    /// <summary>
    /// 下载.
    /// </summary>
    /// <param name="taskInfo">下载信息.</param>
    public void Download(DownloadTaskInfo taskInfo);

    /// <summary>
    /// 取消下载.
    /// </summary>
    /// <param name="taskInfo">下载信息.</param>
    public void Cancel(DownloadTaskInfo taskInfo);
}
