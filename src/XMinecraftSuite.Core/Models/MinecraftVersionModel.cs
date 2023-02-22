// Copyright (c) Keriteal. All rights reserved.

using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models;

/// <summary>
/// Minecraft 版本信息.
/// </summary>
[ToString]
public sealed record MinecraftVersionModel
{
    /// <summary>
    /// 版本类型.
    /// </summary>
    [JsonPropertyName("type")]
    public EnumVersionType Type { get; init; }

    /// <summary>
    /// ComplianceLevel.
    /// </summary>
    [JsonPropertyName("complianceLevel")]
    public int ComplianceLevel { get; init; }

    /// <summary>
    /// 版本Id.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    /// <summary>
    /// 发布时间.
    /// </summary>
    [JsonPropertyName("releaseTime")]
    public DateTime ReleaseTime { get; init; }

    /// <summary>
    /// 文件的Sha1.
    /// </summary>
    [JsonPropertyName("sha1")]
    public string Sha1 { get; init; } = string.Empty;

    /// <summary>
    /// 发布时间?.
    /// </summary>
    [JsonPropertyName("time")]
    public DateTime Time { get; init; }

    /// <summary>
    /// 下载链接.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; init; } = string.Empty;
}
