// Copyright (c) Keriteal. All rights reserved.

using CommunityToolkit.Mvvm.ComponentModel;

namespace XMinecraftSuite.Core.Models.Download;

/// <summary>
/// 下载任务.
/// </summary>
public partial class DownloadTask : ObservableObject
{
    private double progress = 0.0;

    /// <summary>
    /// Initializes a new instance of the <see cref="DownloadTask"/> class.
    /// </summary>
    public DownloadTask()
    {
    }

    /// <summary>
    /// 进度更改的委托.
    /// </summary>
    /// <param name="taskInfo">进度更改的下载信息.</param>
    /// <param name="progress">下载进度.</param>
    public delegate void TaskProgressHandler(DownloadTaskInfo taskInfo, double progress);

    /// <summary>
    /// 任务下载完成的委托.
    /// </summary>
    /// <param name="task">完成的下载信息.</param>
    public delegate void TaskCompletedHandler(DownloadTaskInfo task);

    /// <summary>
    /// 进度更改的事件.
    /// </summary>
    public event TaskProgressHandler? OnProgress;

    /// <summary>
    /// 任务完成的事件.
    /// </summary>
    public event TaskCompletedHandler? OnCompleted;

    /// <summary>
    /// 任务的下载信息.
    /// </summary>
    public required DownloadTaskInfo TaskInfo { get; init; }

    /// <summary>
    /// 下载进度.
    /// </summary>
    public double Progress
    {
        get => progress;
        set
        {
            progress = value;
            OnPropertyChanged(nameof(this.Progress));
            OnProgress?.Invoke(this.TaskInfo, progress);
            if (value >= 100)
            {
                OnCompleted?.Invoke(this.TaskInfo);
            }
        }
    }
}
