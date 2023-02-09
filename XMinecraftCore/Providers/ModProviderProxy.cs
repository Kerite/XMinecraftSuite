using XMinecraftSuite.Core.Excceptions;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;
using XMinecraftSuite.Core.Providers.Mod;

namespace XMinecraftSuite.Core.Providers;

public class ModProviderProxy : ModProvidersRegistry, IModProvider
{
    ModProviderMetaData IModProvider.MetaData { get; } = new ModProviderMetaData("proxy", "Proxy");

    async Task<List<AbstractModSearchResult>> IModProvider.Search(string? modName, int limit, int offset, SearchSortRule order, string[]? gameVersions, EnumModLoader[]? modLoaders)
    {
        var lists = new List<AbstractModSearchResult>();
        foreach (var modProvider in Providers)
        {
            lists.AddRange(await modProvider.Search(modName, limit, offset, order, gameVersions, modLoaders));
        }

        return lists;
    }

    Task<AbstractModDetailsResult> IModProvider.Details(string slug)
    {
        throw new ProxyCantExecuteException();
    }

    async Task<List<AbstractModVersion>> IModProvider.ModVersions(string slug, EnumModLoader[]? modLoaders,
        string[]? gameVersions)
    {
        List<AbstractModVersion> lists = new();
        foreach (var modProvider in Providers)
        {
            lists.AddRange(await modProvider.ModVersions(slug, modLoaders, gameVersions));
        }

        return lists;
    }

    string IModProvider.OriginUrl(string slug)
    {
        throw new ProxyCantExecuteException();
    }
}