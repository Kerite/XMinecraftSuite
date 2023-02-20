using System.Diagnostics;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models;

[Serializable]
public sealed class MinecraftVersionModel
{
    public EnumVersionType Type => MType switch
    {
        "snapshot" => EnumVersionType.Snapshot,
        "release" => EnumVersionType.Release,
        "old_alpha" => EnumVersionType.OldAlpha,
        "old_beta" => EnumVersionType.OldBeta,
        _ => throw new NotImplementedException()
    };

    [JsonPropertyName("complianceLevel")]
    public int ComplianceLevel { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MType { get; set; } = string.Empty;

    [JsonPropertyName("releaseTime")]
    public DateTime ReleaseTime { get; set; }

    [JsonPropertyName("sha1")]
    public string Sha1 { get; set; } = string.Empty;

    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}
