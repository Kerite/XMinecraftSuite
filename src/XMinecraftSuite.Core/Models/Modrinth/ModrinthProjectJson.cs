// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Modrinth;

public class ModrinthProjectJson : AbstractModDetails
{
    public override DateTime Created => MCreated;

    public override string Description => MBody;

    public override int Downloads => MDownloads;

    public override int Followers => MFollowers;

    public override string[] GameVersions => MGameVersions;

    public override string ImageUrl => MIconUrl;

    public override string Issues => MIssues;

    public override string Name => MTitle;

    public override string OriginUrl => $"https://modrinth.com/mod/{MSlug}";

    public override string ShortDescription => MDescription;

    public override EnumModSide Side => MClientSide switch
    {
        "optional" when "required" == MServerSide => EnumModSide.ServerSide,
        "optional" when "optional" == MServerSide => EnumModSide.Optional,
        "required" when "optional" == MServerSide => EnumModSide.ClientSide,
        "required" when "required" == MServerSide => EnumModSide.Both,
        _ => EnumModSide.Unknown
    };

    public override string Source => MSource;
    public override DateTime Updated => MUpdated;
    public override string Wiki => MWiki;

    [JsonPropertyName("body")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MBody { get; set; }

    [JsonPropertyName("client_side")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MClientSide { get; set; }

    [JsonPropertyName("created")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public DateTime MCreated { get; set; }

    [JsonPropertyName("description")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MDescription { get; set; }

    [JsonPropertyName("downloads")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public int MDownloads { get; set; }

    [JsonPropertyName("followers")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public int MFollowers { get; set; }

    [JsonPropertyName("game_versions")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string[] MGameVersions { get; set; }

    [JsonPropertyName("icon_url")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MIconUrl { get; set; }

    [JsonPropertyName("issues_url")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MIssues { get; set; }

    [JsonPropertyName("published")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MPublished { get; set; }

    [JsonPropertyName("server_side")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MServerSide { get; set; }

    [JsonPropertyName("slug")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MSlug { get; set; }

    [JsonPropertyName("source_url")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MSource { get; set; }

    [JsonPropertyName("title")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MTitle { get; set; }

    [JsonPropertyName("updated")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public DateTime MUpdated { get; set; }

    [JsonPropertyName("wiki_url")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MWiki { get; set; }
}
