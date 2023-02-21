// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Modrinth;

/// <summary>
/// Modrinth 的搜索结果.
/// </summary>
[Serializable]
public sealed class ModrinthSearchResult : AbstractModSearchResult
{
    /// <inheritdoc/>
    public override string Author => this.Author_;

    /// <inheritdoc/>
    public override string Description => this.Description_;

    /// <inheritdoc/>
    public override string ImageUrl => this.IconUrl_;

    /// <inheritdoc/>
    public override string LatestGameVersion => this.LatestVersion_;

    /// <inheritdoc/>
    public override string ModSource => "modrinth";

    /// <inheritdoc/>
    public override string Name => this.Title_;

    /// <inheritdoc/>
    public override string Slug => this.Slug_;

    /// <inheritdoc/>
    public override string[] Categories => this.Categories_;

    /// <inheritdoc/>
    public override EnumModLoader[] ModLoaders
    {
        get
        {
            var modLoaders = new List<EnumModLoader>();
            if (this.Categories_.Contains("fabric"))
            {
                modLoaders.Add(EnumModLoader.Fabric);
            }

            if (this.Categories_.Contains("forge"))
            {
                modLoaders.Add(EnumModLoader.Forge);
            }

            if (this.Categories_.Contains("quilt"))
            {
                modLoaders.Add(EnumModLoader.Quilt);
            }

            return modLoaders.ToArray();
        }
    }

    /// <inheritdoc/>
    public override string[] SupportedVersions => this.Versions_;

    /// <summary>
    /// Json value of <see cref="Categories"/>.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("categories")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string[] Categories_ { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Json value of <see cref="SupportedVersions"/>.
    /// </summary>
    [JsonPropertyName("versions")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string[] Versions_ { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Json value of <see cref="Author"/>.
    /// </summary>
    [JsonPropertyName("author")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string Author_ { get; set; } = string.Empty;

    /// <summary>
    /// Json value.
    /// </summary>
    [JsonPropertyName("client_side")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string ClientSide_ { get; set; } = string.Empty;

    /// <summary>
    /// Json value.
    /// </summary>
    [JsonPropertyName("description")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string Description_ { get; set; } = string.Empty;

    /// <summary>
    /// Json value.
    /// </summary>
    [JsonPropertyName("icon_url")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string IconUrl_ { get; set; } = string.Empty;

    /// <summary>
    /// Json value.
    /// </summary>
    [JsonPropertyName("latest_version")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string LatestVersion_ { get; set; } = string.Empty;

    /// <summary>
    /// Json value.
    /// </summary>
    [JsonPropertyName("license")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string License_ { get; set; } = string.Empty;

    /// <summary>
    /// Json value.
    /// </summary>
    [JsonPropertyName("project_id")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string ProjectId_ { get; set; } = string.Empty;

    /// <summary>
    /// Json value.
    /// </summary>
    [JsonPropertyName("server_side")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string ServerSide_ { get; set; } = string.Empty;

    /// <summary>
    /// Json value.
    /// </summary>
    [JsonPropertyName("slug")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string Slug_ { get; set; } = string.Empty;

    /// <summary>
    /// Json value.
    /// </summary>
    [JsonPropertyName("title")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string Title_ { get; set; } = string.Empty;
}
