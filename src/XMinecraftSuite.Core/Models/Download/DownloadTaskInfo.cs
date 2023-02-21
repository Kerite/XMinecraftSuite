// Copyright (c) Keriteal. All rights reserved.

using System.Net;

namespace XMinecraftSuite.Core.Models.Download;

/// <summary>
/// <para>下载任务信息.</para>
/// <seealso cref="DownloadTask"/>
/// </summary>
public class DownloadTaskInfo
{
    /// <summary>
    /// 下载的 Url.
    /// </summary>
    public string Url { get; init; } = string.Empty;

    /// <summary>
    /// 下载路径.
    /// </summary>
    public FileInfo? Path { get; init; }

    /// <summary>
    /// 代理.
    /// </summary>
    public IWebProxy? Proxy { get; init; }

    /// <summary>
    /// 下载的 Cookies.
    /// </summary>
    public string? Cookies { get; init; }

    /// <summary>
    /// 下载的 UserAgent.
    /// </summary>
    public string? UserAgent { get; init; }
}
