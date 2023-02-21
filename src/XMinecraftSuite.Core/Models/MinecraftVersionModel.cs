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
[Serializable]
public sealed class MinecraftVersionModel
{
    /// <summary>
    /// 版本类型.
    /// </summary>
    public EnumVersionType Type => this.MType switch
    {
        "snapshot" => EnumVersionType.Snapshot,
        "release" => EnumVersionType.Release,
        "old_alpha" => EnumVersionType.OldAlpha,
        "old_beta" => EnumVersionType.OldBeta,
        _ => throw new NotImplementedException(),
    };

    /// <summary>
    /// ComplianceLevel.
    /// </summary>
    [JsonPropertyName("complianceLevel")]
    public int ComplianceLevel { get; set; }

    /// <summary>
    /// 版本Id.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 发布时间.
    /// </summary>
    [JsonPropertyName("releaseTime")]
    public DateTime ReleaseTime { get; set; }

    /// <summary>
    /// 文件的Sha1.
    /// </summary>
    [JsonPropertyName("sha1")]
    public string Sha1 { get; set; } = string.Empty;

    /// <summary>
    /// 发布时间?.
    /// </summary>
    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    /// <summary>
    /// 下载链接.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// 版本类型.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonInclude]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string MType { get; init; } = string.Empty;
}
