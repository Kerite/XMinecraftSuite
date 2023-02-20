// Copyright (c) Keriteal. All rights reserved.

using XMinecraftSuite.Core.Services.Config;

namespace XMinecraftSuite.Gui.ViewModels;

/// <summary>
/// 配置界面ViewModel.
/// </summary>
public sealed class ConfigurationViewModel : ViewModelBase
{
    public ConfigurationViewModel(ConfigService configService)
    {
        this.ConfigService = configService;
    }

    private ConfigService ConfigService { get; }
}
