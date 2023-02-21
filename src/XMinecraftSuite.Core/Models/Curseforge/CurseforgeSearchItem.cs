// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Curseforge;

/// <summary>
/// CurseForge 搜索结果 Item.
/// </summary>
[Serializable]
public class CurseforgeSearchItem : AbstractModSearchResult
{
    /// <inheritdoc/>
    public override string Author => string.Join(", ", this.MAuthors.Select(x => x.Name));

    /// <inheritdoc/>
    public override string[] Categories => throw new NotImplementedException();

    /// <inheritdoc/>
    public override string Description => this.MSummary;

    /// <inheritdoc/>
    public override string Slug => this.MSlug;

    /// <inheritdoc/>
    public override string ImageUrl => this.MLogo.ThumbnailUrl;

    /// <inheritdoc/>
    public override string LatestGameVersion => throw new NotImplementedException();

    /// <inheritdoc/>
    public override EnumModLoader[] ModLoaders => throw new NotImplementedException();

    /// <inheritdoc/>
    public override string ModSource => "curseforge";

    /// <inheritdoc/>
    public override string Name => this.MName;

    /// <inheritdoc/>
    public override string[] SupportedVersions => throw new NotImplementedException();

    /// <summary>
    /// JsonValue of <see cref="Author"/>.
    /// </summary>
    [JsonPropertyName("authors")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public AuthorModel[] MAuthors { get; set; } = Array.Empty<AuthorModel>();

    /// <summary>
    /// JsonValue of <see cref="ImageUrl"/>.
    /// </summary>
    [JsonPropertyName("logo")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public LogoModel MLogo { get; set; } = new LogoModel();

    /// <summary>
    /// JsonValue of <see cref="Name"/>.
    /// </summary>
    [JsonPropertyName("name")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MName { get; set; } = string.Empty;

    /// <summary>
    /// JsonValue of <see cref="Slug"/>.
    /// </summary>
    [JsonPropertyName("slug")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MSlug { get; set; } = string.Empty;

    /// <summary>
    /// JsonValue of <see cref="Description"/>.
    /// </summary>
    [JsonPropertyName("summary")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MSummary { get; set; } = string.Empty;
}
