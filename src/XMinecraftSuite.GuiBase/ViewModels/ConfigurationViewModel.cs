using CommunityToolkit.Mvvm.ComponentModel;
using XMinecraftSuite.Core.Services.Config;

namespace XMinecraftSuite.Gui.ViewModels;

public class ConfigurationViewModel : ObservableObject
{
    public ConfigurationViewModel(ConfigService configService)
    {
        ConfigService = configService;
    }

    public ConfigService ConfigService { get; }
}
