using System.Diagnostics;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models;

[Serializable]
public sealed class ModrinthSearchResult : AbstractModSearchResult
{
    [JsonPropertyName("title")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string Title_ { get; set; }

    [JsonPropertyName("author")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string Author_ { get; set; }

    [JsonPropertyName("description")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string Description_ { get; set; }

    [JsonPropertyName("license")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string License_ { get; set; }

    [JsonPropertyName("icon_url")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string IconUrl_ { get; set; }

    [JsonPropertyName("versions")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string[] Versions_ { get; set; }

    [JsonPropertyName("categories")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string[] Categories_ { get; set; }

    [JsonPropertyName("client_side")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string ClientSide_ { get; set; }

    [JsonPropertyName("server_side")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string ServerSide_ { get; set; }

    [JsonPropertyName("latest_version")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string LatestVersion_ { get; set; }

    [JsonPropertyName("slug")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string Slug_ { get; set; }

    [JsonPropertyName("project_id")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string ProjectId_ { get; set; }

    public override string ImageUrl => IconUrl_;
    public override string LatestGameVersion => LatestVersion_;
    public override EnumModLoader[] ModLoaders
    {
        get
        {
            var modLoaders = new List<EnumModLoader>();
            if (Categories_.Contains("fabric"))
            {
                modLoaders.Add(EnumModLoader.Fabric);
            }

            if (Categories_.Contains("forge"))
            {
                modLoaders.Add(EnumModLoader.Forge);
            }

            if (Categories_.Contains("quilt"))
            {
                modLoaders.Add(EnumModLoader.Quilt);
            }

            return modLoaders.ToArray();
        }
    }

    public override string Name => Title_;
    public override string[] SupportedVersions => Versions_;
    public override string Author => Author_;
    public override string[] Categories => Categories_;
    public override string Description => Description_;
    public override string ModSource => "modrinth";
    public override string Slug => Slug_;
}
