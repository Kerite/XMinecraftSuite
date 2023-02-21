// Copyright (c) Keriteal. All rights reserved.

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace XMinecraftSuite.Core.Services.Download;

internal sealed class AriaRequestHelper : IDisposable
{
    private readonly HttpClient httpClient;

    public AriaRequestHelper(string url, string secret)
    {
        httpClient = new HttpClient();
        this.Url = url;
        this.Secret = secret;
    }

    public int RetryCount { get; set; } = 5;

    private string Url { get; }

    private string Secret { get; }

    public void Dispose()
    {
        httpClient.Dispose();
    }

    internal async Task<T> RequestAsync<T>(string method, CancellationToken cancellationToken, params object?[]? parameters)
    {
        var requestUrl = $"{this.Url}/jsonrpc";
        var request = new RpcRequest
        {
            Id = "aria2net",
            Jsonrpc = "2.0",
            Method = method,
            Parameters = new List<object?>(),
        };
        if (!string.IsNullOrEmpty(this.Secret))
        {
            request.Parameters.Add($"token:{this.Secret}");
        }

        if (parameters is { Length: > 0 })
        {
            foreach (var parameter in parameters)
            {
                request.Parameters.Add(parameter);
            }
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
                if (retryCount >= this.RetryCount)
                {
                    throw;
                }

                await Task.Delay(1000, cancellationToken);
            }
        }
    }

    public class RpcRequest
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
