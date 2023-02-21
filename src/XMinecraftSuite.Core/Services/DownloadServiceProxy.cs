// Copyright (c) Keriteal. All rights reserved.

using System.Collections.ObjectModel;
using XMinecraftSuite.Core.Models.Download;
using XMinecraftSuite.Core.Services.Config;
using XMinecraftSuite.Core.Services.Download;

namespace XMinecraftSuite.Core.Services;

/// <summary>
/// Proxy of <see cref="IDownloadService"/>.
/// </summary>
public class DownloadServiceProxy : IDownloadService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DownloadServiceProxy"/> class.
    /// </summary>
    /// <param name="configService">设置管理服务.</param>
    public DownloadServiceProxy(ConfigService configService) => this.ConfigService = configService;

    /// <inheritdoc/>
    public string ServiceName => "proxy";

    /// <inheritdoc/>
    public ObservableCollection<DownloadTask> Tasks => throw new NotImplementedException();

    private ConfigService ConfigService { get; }

    /// <inheritdoc/>
    public void Cancel(DownloadTaskInfo taskInfo) => throw new NotImplementedException();

    /// <inheritdoc/>
    public void Download(DownloadTaskInfo taskInfo) => throw new NotImplementedException();
}
