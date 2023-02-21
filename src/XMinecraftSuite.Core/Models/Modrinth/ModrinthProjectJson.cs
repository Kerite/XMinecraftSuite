// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Modrinth;

/// <summary>
/// Modrinth项目详情定义.
/// </summary>
public class ModrinthProjectJson : AbstractModDetails
{
    /// <inheritdoc/>
    public override string Slug => this.MSlug;

    /// <inheritdoc/>
    public override DateTime Created => this.MCreated;

    /// <inheritdoc/>
    public override string Description => this.MBody;

    /// <inheritdoc/>
    public override int Downloads => this.MDownloads;

    /// <inheritdoc/>
    public override int Followers => this.MFollowers;

    /// <inheritdoc/>
    public override string[] GameVersions => this.MGameVersions;

    /// <inheritdoc/>
    public override string ImageUrl => this.MIconUrl;

    /// <inheritdoc/>
    public override string Issues => this.MIssues;

    /// <inheritdoc/>
    public override string Name => this.MTitle;

    /// <inheritdoc/>
    public override string OriginUrl => $"https://modrinth.com/mod/{this.Slug}";

    /// <inheritdoc/>
    public override string ShortDescription => this.MDescription;

    /// <inheritdoc/>
    public override EnumModSide Side => this.MClientSide switch
    {
        "optional" when this.MServerSide == "required" => EnumModSide.ServerSide,
        "optional" when this.MServerSide == "optional" => EnumModSide.Optional,
        "required" when this.MServerSide == "optional" => EnumModSide.ClientSide,
        "required" when this.MServerSide == "required" => EnumModSide.Both,
        _ => EnumModSide.Unknown,
    };

    /// <inheritdoc/>
    public override string Source => this.MSource;

    /// <inheritdoc/>
    public override DateTime Updated => this.MUpdated;

    /// <inheritdoc/>
    public override string Wiki => this.MWiki;

    /// <summary>
    /// Json value of <see cref="Slug"/>.
    /// </summary>
    [JsonPropertyName("slug")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MSlug { get; init; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="Description"/>.
    /// </summary>
    [JsonPropertyName("body")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MBody { get; init; } = string.Empty;

    /// <summary>
    /// Json value.
    /// </summary>
    [JsonPropertyName("client_side")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MClientSide { get; init; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="Created"/>.
    /// </summary>
    [JsonPropertyName("created")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public DateTime MCreated { get; init; }

    /// <summary>
    /// Json value of <see cref="ShortDescription"/>.
    /// </summary>
    [JsonPropertyName("description")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MDescription { get; init; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="Downloads"/>.
    /// </summary>
    [JsonPropertyName("downloads")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public int MDownloads { get; init; }

    /// <summary>
    /// Json value of <see cref="Followers"/>.
    /// </summary>
    [JsonPropertyName("followers")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public int MFollowers { get; init; }

    /// <summary>
    /// Json value of <see cref="GameVersions"/>.
    /// </summary>
    [JsonPropertyName("game_versions")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string[] MGameVersions { get; init; } = Array.Empty<string>();

    /// <summary>
    /// Json value of <see cref="ImageUrl"/>.
    /// </summary>
    [JsonPropertyName("icon_url")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MIconUrl { get; init; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="Issues"/>.
    /// </summary>
    [JsonPropertyName("issues_url")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MIssues { get; init; } = string.Empty;

    /// <summary>
    /// Json value.
    /// </summary>
    [JsonPropertyName("published")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MPublished { get; init; } = string.Empty;

    /// <summary>
    /// Json value.
    /// </summary>
    [JsonPropertyName("server_side")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MServerSide { get; init; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="Source"/>.
    /// </summary>
    [JsonPropertyName("source_url")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MSource { get; init; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="Name"/>.
    /// </summary>
    [JsonPropertyName("title")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MTitle { get; init; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="Updated"/>.
    /// </summary>
    [JsonPropertyName("updated")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public DateTime MUpdated { get; init; }

    /// <summary>
    /// Json value of <see cref="Wiki"/>.
    /// </summary>
    [JsonPropertyName("wiki_url")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MWiki { get; init; } = string.Empty;
}
