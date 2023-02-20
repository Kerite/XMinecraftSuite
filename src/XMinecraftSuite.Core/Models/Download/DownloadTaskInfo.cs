
using System.Net;

namespace XMinecraftSuite.Core.Models.Download;

public class DownloadTaskInfo
{
    public string Url { get; init; } = string.Empty;
    public FileInfo? Path { get; init; }
    public IWebProxy? Proxy { get; init; }
    public string? Cookies { get; init; }
    public string? UserAgent { get; init; }
}
