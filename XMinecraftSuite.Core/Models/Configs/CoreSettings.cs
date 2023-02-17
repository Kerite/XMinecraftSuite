using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using XMinecraftSuite.Core.Services.Config;

namespace XMinecraftSuite.Core.Models.Configs;

[Config("Core")]
public class CoreSettings : ObservableObject
{
    public string DefaultModProvider { get; set; } = "modrinth";
    public string DownloadService { get; set; } = "downloader";
    public string Aria2JsonRpc { get; set; } = "http://localhost:6800/jsonrpc";
    public string Aria2Secret { get; set; } = string.Empty;
    public IEnumerable<VersionDefination> MCVersions { get; } = new List<VersionDefination>();
}
