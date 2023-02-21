// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics;
using System.Text.Json.Serialization;
using CommunityToolkit.Diagnostics;
using XMinecraftSuite.Core.JsonConverter;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Modrinth;

/// <summary>
/// Modrinth Mod 版本.
/// </summary>
public sealed class ModrinthModVersion : AbstractModVersion
{
    /// <inheritdoc/>
    public override string ChangeLog => this.MChangeLog;

    /// <inheritdoc/>
    public override string Name => this.MName;

    /// <inheritdoc/>
    public override string Number => this.MVersionNumber;

    /// <inheritdoc/>
    public override string ProjectId => this.MProjectId;

    /// <inheritdoc/>
    public override string VersionId => this.MId;

    /// <inheritdoc/>
    public override int Downloads => this.MDownloads;

    /// <inheritdoc/>
    public override EnumModVersionType ModVersionType => this.MModVersionType switch
    {
        "alpha" => EnumModVersionType.Alpha,
        "beta" => EnumModVersionType.Beta,
        "release" => EnumModVersionType.Release,
        _ => ThrowHelper.ThrowArgumentException<EnumModVersionType>(nameof(this.MModVersionType)),
    };

    /// <inheritdoc/>
    public override DateTime PublishedTime => this.MDatePublished;

    /// <inheritdoc/>
    public override string[] GameVersions => this.MGameVersions;

    /// <inheritdoc/>
    public override AbstractModDependency[] ModDependencies => this.MModDependencies;

    /// <inheritdoc/>
    public override AbstractModFile[] ModFiles => this.MModFiles;

    /// <inheritdoc/>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Critical Code Smell", "S2365:Properties should not make collection or array copies", Justification = "Reviewed.")]
    public override EnumModLoader[] ModLoaders => this.MModLoaders.Select(str => str switch
        {
            "fabric" => EnumModLoader.Fabric,
            "forge" => EnumModLoader.Forge,
            "quilt" => EnumModLoader.Quilt,
            _ => throw new Exception($"Unrecognized mod loader{str}"),
        })
        .ToArray();

    /// <summary>
    /// Json value of <see cref="GameVersions"/>.
    /// </summary>
    [JsonPropertyName("game_versions")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string[] MGameVersions { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Json value of <see cref="ModFiles"/>.
    /// </summary>
    [JsonPropertyName("files")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public ModrinthModFile[] MModFiles { get; set; } = Array.Empty<ModrinthModFile>();

    /// <summary>
    /// Json value of <see cref="ModLoaders"/>.
    /// </summary>
    [JsonPropertyName("loaders")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string[] MModLoaders { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Json value of <see cref="ModDependencies"/>.
    /// </summary>
    [JsonPropertyName("dependencies")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public ModrinthModDependency[] MModDependencies { get; set; } = Array.Empty<ModrinthModDependency>();

    /// <summary>
    /// Json value of <see cref="PublishedTime"/>.
    /// </summary>
    [JsonPropertyName("date_published")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public DateTime MDatePublished { get; set; }

    /// <summary>
    /// Json value of <see cref="Downloads"/>.
    /// </summary>
    [JsonPropertyName("downloads")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public int MDownloads { get; set; } = -1;

    /// <summary>
    /// Json value of <see cref="ModVersionType"/>.
    /// </summary>
    [JsonPropertyName("version_type")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MModVersionType { get; set; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="ChangeLog"/>.
    /// </summary>
    [JsonPropertyName("changelog")]
    [JsonConverter(typeof(TrimmingConverter))]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MChangeLog { get; set; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="Name"/>.
    /// </summary>
    [JsonPropertyName("name")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MName { get; set; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="Number"/>.
    /// </summary>
    [JsonPropertyName("version_number")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MVersionNumber { get; set; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="VersionId"/>.
    /// </summary>
    [JsonPropertyName("id")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MId { get; set; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="ProjectId"/>.
    /// </summary>
    [JsonPropertyName("project_id")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MProjectId { get; set; } = string.Empty;
}
