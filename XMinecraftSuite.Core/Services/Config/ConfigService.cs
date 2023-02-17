namespace XMinecraftSuite.Core.Services.Config;

public class ConfigService
{
    internal ConfigService(Dictionary<Type, object> configs)
    {
        Configs = configs;
    }

    private Dictionary<Type, object> Configs { get; }

    public T GetConfig<T>() where T : class
    {
        return (T)Configs[typeof(T)];
    }
}
