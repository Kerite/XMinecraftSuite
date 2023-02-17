using System.Net;

namespace XMinecraftSuite.Core.Models;

public class DownloadTask
{
    public delegate void TaskProgressHandler(double Progress);

    private double progress = 0.0;
    public string Url { get; init; } = string.Empty;
    public FileInfo? Path { get; init; }
    public IWebProxy? Proxy { get; init; }
    public string? Cookies { get; init; }
    public string? UserAgent { get; init; }

    public double Progress
    {
        get => progress;
        set
        {
            progress = value;
            OnProgress?.Invoke(progress);
        }
    }

    public event TaskProgressHandler? OnProgress;
}
