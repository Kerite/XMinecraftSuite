using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Configs;

namespace XMinecraftSuite.Core.Services.Download;

public class AriaDownloadService : IDownloadService
{
    public event IDownloadService.DownloadProgressHandler? OnProgress;

    public AriaDownloadService(ICoreSettings options)
    {
        AppSettings = options;
        MRequestHelper = new RequestHelper(options.Aria2JsonRpc, options.Aria2Secret);
    }

    private ICoreSettings AppSettings { get; }
    private RequestHelper MRequestHelper { get; }

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
