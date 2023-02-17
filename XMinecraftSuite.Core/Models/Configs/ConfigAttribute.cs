namespace XMinecraftSuite.Core.Models.Configs;

[AttributeUsage(AttributeTargets.Class)]
public class ConfigAttribute : Attribute
{
    public ConfigAttribute(string configName)
    {
        ConfigName = configName;
    }

    public string ConfigName { get; }
}
