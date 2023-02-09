using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;

namespace XMinecraftSuite.Core.Models
{
    public class ModrinthModFile : AbstractModFile
    {
        [JsonPropertyName("filename")] public string MFileName { get; set; }

        [JsonPropertyName("primary")] public Boolean MPrimary { get; set; }

        [JsonPropertyName("url")] public string MUrl { get; set; }

        [JsonPropertyName("hashes")] public Dictionary<string, string> MHashes { get; set; }

        public override string FileName => MFileName;
        public override string DownloadUrl => MUrl;
        public override string Hash => MHashes["sha1"];
        public override bool Primary => MPrimary;
    }
}