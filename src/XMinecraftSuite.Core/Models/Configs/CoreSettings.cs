// Copyright (c) Keriteal. All rights reserved.

using CommunityToolkit.Mvvm.ComponentModel;

namespace XMinecraftSuite.Core.Models.Configs;

/// <summary>
/// 核心设置.
/// </summary>
[Config("Core")]
public class CoreSettings : ObservableObject
{
    /// <summary>
    /// 默认的ModProvider.
    /// </summary>
    public string DefaultModProvider { get; set; } = "modrinth";

    /// <summary>
    /// 使用的下载器.
    /// </summary>
    public string DownloadService { get; set; } = "downloader";

    /// <summary>
    /// Aria2的JsonRpc.
    /// </summary>
    public string Aria2JsonRpc { get; set; } = "http://localhost:6800/jsonrpc";

    /// <summary>
    /// Aria2的密钥.
    /// </summary>
    public string Aria2Secret { get; set; } = string.Empty;

    /// <summary>
    /// MC的版本.
    /// </summary>
    public IEnumerable<VersionDefination> MCVersions { get; } = new List<VersionDefination>();
}
