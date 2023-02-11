using System.Diagnostics;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models;

public class ModrinthModVersion : AbstractModVersion
{
    [JsonPropertyName("name")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MName { get; set; }

    [JsonPropertyName("version_number")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MVersionNumber { get; set; }

    [JsonPropertyName("date_published")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public DateTime MDatePublished { get; set; }

    [JsonPropertyName("game_versions")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string[] MGameVersions { get; set; }

    [JsonPropertyName("loaders")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string[] MModLoaders { get; set; }

    [JsonPropertyName("files")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public ModrinthModFile[] MModFiles { get; set; }

    public override string Name => MName;
    public override string Number => MVersionNumber;
    public override DateTime PublishedTime => MDatePublished;
    public override string[] GameVersions => MGameVersions;

    public override EnumModLoader[] ModLoaders => MModLoaders
                .Select(str =>
                {
                    return str switch
                    {
                        "fabric" => EnumModLoader.Fabric,
                        "forge" => EnumModLoader.Forge,
                        "quilt" => EnumModLoader.Quilt,
                        _ => throw new Exception($"Unrecognized mod loader{str}")
                    };
                })
                .ToArray();

    public override AbstractModFile[] ModFiles => MModFiles;
}
