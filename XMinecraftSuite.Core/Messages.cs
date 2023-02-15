using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Providers.Mod;

namespace XMinecraftSuite.Core;

internal record ModProviderRegisteredMessage(ModProviderMetaData MetaData, IModProvider Provider);