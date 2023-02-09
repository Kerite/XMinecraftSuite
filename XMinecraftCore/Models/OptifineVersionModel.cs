using System.Text.Json.Serialization;

namespace XMinecraftSuite.Core.Models
{
    [Serializable]
    public sealed class OptifineVersionModel
    {
        [JsonPropertyName("mcversion")] public string McVersion { get; set; }

        [JsonPropertyName("patch")] public string Patch { get; set; }

        [JsonPropertyName("filename")] public string Filename { get; set; }

        [JsonPropertyName("forge")] public string ForgeVersion { get; set; }
    }
}