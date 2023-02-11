using System.Text.Json.Serialization;

namespace XMinecraftSuite.Core.Models
{
    [Serializable]
    public sealed class OptifineVersionModel
    {
        [JsonPropertyName("mcversion")]
        public string McVersion { get; set; } = string.Empty;

        [JsonPropertyName("patch")]
        public string Patch { get; set; } = string.Empty;

        [JsonPropertyName("filename")]
        public string Filename { get; set; } = string.Empty;

        [JsonPropertyName("forge")]
        public string ForgeVersion { get; set; } = string.Empty;
    }
}
