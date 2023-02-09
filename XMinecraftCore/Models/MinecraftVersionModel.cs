using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models
{
    [Serializable]
    public sealed class MinecraftVersionModel
    {
        [JsonPropertyName("id")] public string Id { get; set; }

        [JsonPropertyName("type")] public string MType { get; set; }

        [JsonPropertyName("url")] public string Url { get; set; }

        [JsonPropertyName("time")] public DateTime Time { get; set; }

        [JsonPropertyName("releaseTime")] public DateTime ReleaseTime { get; set; }

        [JsonPropertyName("sha1")] public string Sha1 { get; set; }

        [JsonPropertyName("complianceLevel")] public int ComplianceLevel { get; set; }

        public EnumVersionType Type =>
            MType switch
            {
                "snapshot" => EnumVersionType.Snapshot,
                "release" => EnumVersionType.Release,
                "old_alpha" => EnumVersionType.OldAlpha,
                "old_beta" => EnumVersionType.OldBeta,
                _ => throw new NotImplementedException()
            };
    }
}