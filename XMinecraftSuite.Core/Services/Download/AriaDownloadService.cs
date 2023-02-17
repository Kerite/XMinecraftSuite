using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Services.Config;

namespace XMinecraftSuite.Core.Services.Download;

internal class AriaDownloadService : IDownloadService
{
    public AriaDownloadService(ConfigService configService)
    {
        AppSettings = configService.GetConfig<CoreSettings>();
        MRequestHelper = new RequestHelper(AppSettings.Aria2JsonRpc, AppSettings.Aria2Secret);
    }

    private CoreSettings AppSettings { get; }
    private RequestHelper MRequestHelper { get; }
    public event IDownloadService.DownloadProgressHandler? OnProgress;

    public string ServiceName => "aria";
    public ObservableCollection<DownloadTask> Tasks { get; } = new();

    public void Download(DownloadTask task)
    {
        throw new NotImplementedException();
    }

    public void Cancel()
    {
        throw new NotImplementedException();
    }

    public class Request
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("jsonrpc")]
        public string Jsonrpc { get; set; } = string.Empty;

        [JsonPropertyName("method")]
        public string Method { get; set; } = string.Empty;

        [JsonPropertyName("params")]
        public IList<object?>? Parameters { get; set; }
    }
}
