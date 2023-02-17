using System.Collections.ObjectModel;
using XMinecraftSuite.Core.Models.Configs;

namespace XMinecraftSuite.Core.Services;

public class JavaService
{
    public JavaService(ICoreSettings appSettings)
    {
        CoreSettings = appSettings;
    }

    private ICoreSettings CoreSettings { get; }

    public ObservableCollection<string> JavaRuntimeList { get; } = new();
}
