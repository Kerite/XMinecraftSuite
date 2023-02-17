using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Providers.Mod;

namespace XMinecraftSuite.Core;

public record ModProviderRegisteredMessage(ModProviderMetaData MetaData, IModProvider Provider);

/// <summary>
///     当配置文件被修改时触发这个消息
/// </summary>
/// <param name="ChangedConfigModel"></param>
public record ConfugurationChangedMessage(Type ChangedConfigModel);
