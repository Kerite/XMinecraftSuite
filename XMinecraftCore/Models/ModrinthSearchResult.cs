using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models
{
    [Serializable]
    public sealed class ModrinthSearchResult : AbstractModSearchResult
    {
        [JsonPropertyName("title")] public string Title_ { get; set; }

        [JsonPropertyName("author")] public string Author_ { get; set; }

        [JsonPropertyName("description")] public string Description_ { get; set; }

        [JsonPropertyName("license")] public string License_ { get; set; }

        [JsonPropertyName("icon_url")] public string IconUrl_ { get; set; }

        [JsonPropertyName("versions")] public string[] Versions_ { get; set; }

        [JsonPropertyName("categories")] public string[] Categories_ { get; set; }

        [JsonPropertyName("client_side")] public string ClientSide_ { get; set; }

        [JsonPropertyName("server_side")] public string ServerSide_ { get; set; }

        [JsonPropertyName("latest_version")] public string LatestVersion_ { get; set; }

        [JsonPropertyName("slug")] public string Slug_ { get; set; }

        [JsonPropertyName("project_id")] public string ProjectId_ { get; set; }

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
}