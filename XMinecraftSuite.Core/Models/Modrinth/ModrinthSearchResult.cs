using System.Diagnostics;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Modrinth
{
    [Serializable]
    public sealed class ModrinthSearchResult : AbstractModSearchResult
    {
        public override string Author => Author_;
        public override string Description => Description_;
        public override string ImageUrl => IconUrl_;
        public override string LatestGameVersion => LatestVersion_;
        public override string ModSource => "modrinth";
        public override string Name => Title_;
        public override string Slug => Slug_;
        public override string[] Categories => Categories_;
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
        public override string[] SupportedVersions => Versions_;

        [JsonPropertyName("categories")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string[] Categories_ { get; set; } = Array.Empty<string>();

        [JsonPropertyName("versions")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string[] Versions_ { get; set; } = Array.Empty<string>();

        [JsonPropertyName("author")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string Author_ { get; set; } = string.Empty;

        [JsonPropertyName("client_side")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string ClientSide_ { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string Description_ { get; set; } = string.Empty;

        [JsonPropertyName("icon_url")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string IconUrl_ { get; set; } = string.Empty;

        [JsonPropertyName("latest_version")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string LatestVersion_ { get; set; } = string.Empty;

        [JsonPropertyName("license")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string License_ { get; set; } = string.Empty;

        [JsonPropertyName("project_id")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string ProjectId_ { get; set; } = string.Empty;

        [JsonPropertyName("server_side")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string ServerSide_ { get; set; } = string.Empty;

        [JsonPropertyName("slug")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string Slug_ { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string Title_ { get; set; } = string.Empty;
    }
}
