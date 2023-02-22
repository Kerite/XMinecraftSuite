// Copyright (c) Keriteal. All rights reserved.

using System.Text.Json.Serialization;

namespace XMinecraftSuite.Core.Models;

/// <summary>
/// Optifine 版本.
/// </summary>
[ToString]
public sealed class OptifineVersionModel
{
    /// <summary>
    /// 文件名.
    /// </summary>
    [JsonPropertyName("filename")]
    public string Filename { get; set; } = string.Empty;

    /// <summary>
    /// 对应的 Forge版本.
    /// </summary>
    [JsonPropertyName("forge")]
    public string ForgeVersion { get; set; } = string.Empty;

    /// <summary>
    /// 对应的 Minecraft版本.
    /// </summary>
    [JsonPropertyName("mcversion")]
    public string McVersion { get; set; } = string.Empty;

    /// <summary>
    /// Optifine 版本补丁号.
    /// </summary>
    [JsonPropertyName("patch")]
    public string Patch { get; set; } = string.Empty;
}
