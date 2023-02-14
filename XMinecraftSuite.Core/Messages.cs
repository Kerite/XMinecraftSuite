using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Providers.Mod;

namespace XMinecraftSuite.Core
{
    record ModProviderRegisteredMessage(ModProviderMetaData MetaData, IModProvider Provider);
}
