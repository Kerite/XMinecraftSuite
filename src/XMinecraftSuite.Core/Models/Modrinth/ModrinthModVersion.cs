using System.Diagnostics;
using System.Text.Json.Serialization;
using CommunityToolkit.Diagnostics;
using XMinecraftSuite.Core.JsonConverter;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Modrinth;

public class ModrinthModVersion : AbstractModVersion
{
    public override string ChangeLog => MChangeLog;
    public override string Name => MName;
    public override string Number => MVersionNumber;
    public override string ProjectId => MProjectId;
    public override string VersionId => MId;
    public override int Downloads => MDownloads;

    public override EnumModVersionType ModVersionType => MModVersionType switch
    {
        "alpha" => EnumModVersionType.Alpha,
        "beta" => EnumModVersionType.Beta,
        "release" => EnumModVersionType.Release,
        _ => ThrowHelper.ThrowArgumentException<EnumModVersionType>(nameof(MModVersionType))
    };

    public override DateTime PublishedTime => MDatePublished;
    public override string[] GameVersions => MGameVersions;
    public override AbstractModDependency[] ModDependencies => MModDependencies;
    public override AbstractModFile[] ModFiles => MModFiles;

    public override EnumModLoader[] ModLoaders => MModLoaders.Select(str => str switch
        {
            "fabric" => EnumModLoader.Fabric,
            "forge" => EnumModLoader.Forge,
            "quilt" => EnumModLoader.Quilt,
            _ => throw new Exception($"Unrecognized mod loader{str}")
        })
        .ToArray();

    [JsonPropertyName("game_versions")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string[] MGameVersions { get; set; } = Array.Empty<string>();

    [JsonPropertyName("files")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public ModrinthModFile[] MModFiles { get; set; } = Array.Empty<ModrinthModFile>();

    [JsonPropertyName("loaders")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string[] MModLoaders { get; set; } = Array.Empty<string>();

    [JsonPropertyName("dependencies")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public ModrinthModDependency[] MModDependencies { get; set; } = Array.Empty<ModrinthModDependency>();

    [JsonPropertyName("date_published")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public DateTime MDatePublished { get; set; }

    [JsonPropertyName("downloads")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public int MDownloads { get; set; } = -1;

    [JsonPropertyName("version_type")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MModVersionType { get; set; } = string.Empty;

    [JsonPropertyName("changelog")]
    [JsonConverter(typeof(TrimmingConverter))]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MChangeLog { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MName { get; set; } = string.Empty;

    [JsonPropertyName("version_number")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MVersionNumber { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MId { get; set; } = string.Empty;

    [JsonPropertyName("project_id")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MProjectId { get; set; } = string.Empty;
}
