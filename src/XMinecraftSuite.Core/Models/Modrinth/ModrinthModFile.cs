// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;

namespace XMinecraftSuite.Core.Models.Modrinth;

/// <summary>
/// Mod 文件Model，来自 Modrinth.
/// </summary>
public class ModrinthModFile : AbstractModFile
{
    /// <inheritdoc/>
    public override string Filename => this.MFileName;

    /// <inheritdoc/>
    public override string DownloadUrl => this.MUrl;

    /// <inheritdoc/>
    public override string Hash => this.MHashes["sha1"];

    /// <inheritdoc/>
    public override bool Primary => this.MPrimary;

    /// <summary>
    /// Json value of <see cref="Filename"/>.
    /// </summary>
    [JsonPropertyName("filename")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MFileName { get; init; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="Hash"/>.
    /// </summary>
    [JsonPropertyName("hashes")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public Dictionary<string, string> MHashes { get; init; } = new();

    /// <summary>
    /// Json value of <seealso cref="Primary"/>.
    /// </summary>
    [JsonPropertyName("primary")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool MPrimary { get; init; }

    /// <summary>
    /// Json value of <see cref="DownloadUrl"/>.
    /// </summary>
    [JsonPropertyName("url")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MUrl { get; init; } = string.Empty;
}
