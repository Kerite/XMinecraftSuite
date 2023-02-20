using System.Diagnostics;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;

namespace XMinecraftSuite.Core.Models.Modrinth;

public class ModrinthModFile : AbstractModFile
{
    public override string Filename => MFileName;
    public override string DownloadUrl => MUrl;
    public override string Hash => MHashes["sha1"];
    public override bool Primary => MPrimary;

    [JsonPropertyName("filename")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的 属性“MFileName”必须包含非 null 值。请考虑将 属性 声明为可以为 null。
    public string MFileName { get; set; }

#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的 属性“MFileName”必须包含非 null 值。请考虑将 属性 声明为可以为 null。

    [JsonPropertyName("hashes")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的 属性“MHashes”必须包含非 null 值。请考虑将 属性 声明为可以为 null。
    public Dictionary<string, string> MHashes { get; set; }

#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的 属性“MHashes”必须包含非 null 值。请考虑将 属性 声明为可以为 null。

    [JsonPropertyName("primary")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool MPrimary { get; set; }

    [JsonPropertyName("url")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的 属性“MUrl”必须包含非 null 值。请考虑将 属性 声明为可以为 null。
    public string MUrl { get; set; }

#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的 属性“MUrl”必须包含非 null 值。请考虑将 属性 声明为可以为 null。
}
