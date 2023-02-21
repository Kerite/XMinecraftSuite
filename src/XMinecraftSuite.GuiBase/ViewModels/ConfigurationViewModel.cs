// Copyright (c) Keriteal. All rights reserved.

using XMinecraftSuite.Core.Services.Config;

namespace XMinecraftSuite.Gui.ViewModels;

/// <summary>
/// 配置界面ViewModel.
/// </summary>
public sealed class ConfigurationViewModel : ViewModelBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationViewModel"/> class.
    /// </summary>
    /// <param name="configService">配置服务.</param>
    public ConfigurationViewModel(ConfigService configService)
    {
        this.ConfigService = configService;
    }

    private ConfigService ConfigService { get; }
}
