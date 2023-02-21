// Copyright (c) Keriteal. All rights reserved.

using System.Collections.ObjectModel;
using IDManLib;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Models.Download;
using XMinecraftSuite.Core.Services.Config;
using XMinecraftSuite.Core.Services.Download;

namespace XMinecraftSuite.Wpf.Services.DownloadServices;

/// <summary>
/// IDM下载服务.
/// </summary>
public sealed class IdmDownloadManager : IDownloadService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IdmDownloadManager"/> class.
    /// </summary>
    /// <param name="options">自动注入的配置服务.</param>
    public IdmDownloadManager(ConfigService options)
    {
        this.CoreConfigurations = options.GetConfig<CoreSettings>();
    }

    /// <summary>
    /// 核心设置.
    /// </summary>
    public CoreSettings CoreConfigurations { get; set; }

    /// <inheritdoc/>
    public string ServiceName => "idm";

    /// <inheritdoc/>
    public ObservableCollection<DownloadTask> Tasks { get; } = new();

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public void Cancel(DownloadTaskInfo taskInfo) => throw new NotImplementedException();
}
