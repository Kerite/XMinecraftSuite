using System.Text;
using System.Text.Json;
using static XMinecraftSuite.Core.Services.Download.AriaDownloadService;

namespace XMinecraftSuite.Core.Services.Download;

internal class RequestHelper
{
    public RequestHelper(string url, string secret)
    {
        httpClient = new HttpClient();
        Url = url;
        Secret = secret;
    }

    private readonly HttpClient httpClient;
    private string Url { get; }
    private string Secret { get; }
    public int RetryCount { get; set; } = 5;

    internal async Task<T> Request<T>(string method, CancellationToken cancellationToken, params object?[]? parameters)
    {
        var requestUrl = $"{Url}/jsonrpc";
        var request = new Request
        {
            Id = "aria2net",
            Jsonrpc = "2.0",
            Method = method,
            Parameters = new List<object?>()
        };

        if (!string.IsNullOrEmpty(Secret)) { request.Parameters.Add($"token:{Secret}"); }

        if (parameters is { Length: > 0 })
        {
            foreach (var parameter in parameters)
                request.Parameters.Add(parameter);
        }

        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        var retryCount = 0;
        while (true)
        {
            try
            {
                var response = await httpClient.PostAsync(requestUrl, content, cancellationToken);
                var buffer = await response.Content.ReadAsStringAsync(cancellationToken);
                return JsonSerializer.Deserialize<T>(buffer)!;
            }
            catch
            {
                retryCount++;
                if (retryCount >= RetryCount) { throw; }

                await Task.Delay(1000, cancellationToken);
            }
        }
    }
}
