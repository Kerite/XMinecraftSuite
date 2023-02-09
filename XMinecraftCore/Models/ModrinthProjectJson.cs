using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models
{
    public class ModrinthProjectJson : AbstractModDetailsResult
    {
        #region Fields

        [JsonPropertyName("slug")] public string MSlug { get; set; }

        [JsonPropertyName("title")] public string MTitle { get; set; }

        [JsonPropertyName("icon_url")] public string MIconUrl { get; set; }

        [JsonPropertyName("downloads")] public int MDownloads { get; set; }

        [JsonPropertyName("followers")] public int MFollowers { get; set; }

        [JsonPropertyName("description")] public string MDescription { get; set; }

        [JsonPropertyName("body")] public string MBody { get; set; }

        [JsonPropertyName("client_side")] public string MClientSide { get; set; }

        [JsonPropertyName("server_side")] public string MServerSide { get; set; }

        [JsonPropertyName("published")] public string MPublished { get; set; }

        [JsonPropertyName("updated")] public string MUpdated { get; set; }

        [JsonPropertyName("issues_url")] public string MIssues { get; set; }

        [JsonPropertyName("source_url")] public string MSource { get; set; }

        [JsonPropertyName("wiki_url")] public string MWiki { get; set; }

        [JsonPropertyName("game_versions")] public string[] MGameVersions { get; set; }

        #endregion Fields

        #region Overrides

        public override string Name => MTitle;
        public override string ShortDescription => MDescription;
        public override string Description => MBody;
        public override string ImageUrl => MIconUrl;
        public override string[] GameVersions => MGameVersions;

        public override string OriginUrl => "https://modrinth.com/mod/" + MSlug;

        public override string Issues => MIssues;
        public override string Wiki => MWiki;
        public override string Source => MSource;
        public override int Downloads => MDownloads;
        public override int Followers => MFollowers;
        public override DateTime Updated => throw new NotImplementedException();
        public override DateTime Created => throw new NotImplementedException();

        public override EnumModSide Side
        {
            get
            {
                return MClientSide switch
                {
                    "optional" when "required" == MServerSide => EnumModSide.ServerSide,
                    "optional" when "optional" == MServerSide => EnumModSide.Optional,
                    "required" when "optional" == MServerSide => EnumModSide.ClientSide,
                    "required" when "required" == MServerSide => EnumModSide.Both,
                    _ => EnumModSide.Unknown
                };
            }
        }

        #endregion Overrides
    }
}