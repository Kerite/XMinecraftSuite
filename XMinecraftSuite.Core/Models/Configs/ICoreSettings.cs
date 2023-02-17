namespace XMinecraftSuite.Core.Models.Configs;

public interface ICoreSettings
{
    public string DefaultModProvider { get; set; }
    public string DownloadService { get; set; }
    public string Aria2JsonRpc { get; set; }
    public string Aria2Secret { get; set; }
    public VersionDefination[] VersionDefinations { get; set; }
}
