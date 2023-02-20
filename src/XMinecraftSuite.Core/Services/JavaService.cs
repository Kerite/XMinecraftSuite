using System.Collections.ObjectModel;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Services.Config;

namespace XMinecraftSuite.Core.Services;

public class JavaService
{
    public JavaService(ConfigService appSettings)
    {
        CoreSettings = appSettings.GetConfig<CoreSettings>();
    }

    public ObservableCollection<string> JavaRuntimeList { get; } = new();

    private CoreSettings CoreSettings { get; }
}
