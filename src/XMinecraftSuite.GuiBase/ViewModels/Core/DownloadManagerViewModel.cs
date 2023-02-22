// Copyright (c) Keriteal. All rights reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Services;
using XMinecraftSuite.Core.Services.Config;

namespace XMinecraftSuite.Gui.ViewModels;

/// <summary>
/// 下载管理界面ViewModel.
/// </summary>
public sealed partial class DownloadManagerViewModel : ObservableObject
{
    [ObservableProperty]
    private DownloadServiceProxy downloadService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DownloadManagerViewModel"/> class.
    /// </summary>
    /// <param name="coreSettings">核心设置.</param>
    /// <param name="downloadServiceProxy">下载服务代理.</param>
    public DownloadManagerViewModel(ConfigService coreSettings, DownloadServiceProxy downloadServiceProxy)
    {
        downloadService = downloadServiceProxy;
        this.CoreSettings = coreSettings.GetConfig<CoreSettings>();
    }

    /// <summary>
    /// 核心设置.
    /// </summary>
    public CoreSettings CoreSettings { get; set; }
}
