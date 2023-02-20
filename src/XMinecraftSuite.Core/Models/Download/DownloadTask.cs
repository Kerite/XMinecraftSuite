using CommunityToolkit.Mvvm.ComponentModel;

namespace XMinecraftSuite.Core.Models.Download;

/// <summary>
/// 下载任务.
/// </summary>
public partial class DownloadTask : ObservableObject
{
    public delegate void TaskProgressHandler(DownloadTaskInfo taskInfo, double progress);

    public delegate void TaskCompletedHandler(DownloadTaskInfo task);

    private double progress = 0.0;

    public event TaskProgressHandler? OnProgress;

    public event TaskCompletedHandler? OnCompleted;

    public DownloadTaskInfo TaskInfo { get; }

    public DownloadTask(DownloadTaskInfo task)
    {
        TaskInfo = task;
    }

    public double Progress
    {
        get => progress;
        set
        {
            progress = value;
            OnPropertyChanged(nameof(Progress));
            OnProgress?.Invoke(TaskInfo, progress);
            if (value >= 100)
            {
                OnCompleted?.Invoke(TaskInfo);
            }
        }
    }
}
