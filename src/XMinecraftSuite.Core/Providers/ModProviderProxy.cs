using XMinecraftSuite.Core.Exceptions;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;
using XMinecraftSuite.Core.Providers.Mod;

namespace XMinecraftSuite.Core.Providers;

public class ModProviderProxy : ModProvidersRegistry, IModProvider
{
    ModProviderMetaData IModProvider.MetaData { get; } = new()
    {
        ProviderId = "proxy",
        ProviderName = "Mod Providers Proxy",
        Icon = null,
        IsLocal = false
    };

    Task<AbstractModDetails> IModProvider.GetModDetailAsync(string slug)
    {
        throw new ProxyCantExecuteException();
    }

    async Task<List<AbstractModVersion>> IModProvider.GetModVersionsAsync(string slug, EnumModLoader[]? modLoaders,
        string[]? gameVersions)
    {
        List<AbstractModVersion> lists = new();
        foreach (var modProvider in Providers)
            lists.AddRange(await modProvider.GetModVersionsAsync(slug, modLoaders, gameVersions));
        return lists;
    }

    string IModProvider.OriginUrl(string slug)
    {
        throw new ProxyCantExecuteException();
    }

    async Task<List<AbstractModSearchResult>> IModProvider.SearchModAsync(string? modName, int limit, int offset,
        SearchSortRule order, string[]? gameVersions, EnumModLoader[]? modLoaders)
    {
        var lists = new List<AbstractModSearchResult>();
        foreach (var modProvider in Providers)
            lists.AddRange(await modProvider.SearchModAsync(modName, limit, offset, order, gameVersions, modLoaders));
        return lists;
    }
}
