// Copyright (c) Keriteal. All rights reserved.

using XMinecraftSuite.Core.Exceptions;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;
using XMinecraftSuite.Core.Providers.Mod;

namespace XMinecraftSuite.Core.Providers;

/// <summary>
/// ModProvider的代理.
/// </summary>
public class ModProviderProxy : ModProvidersRegistry, IModProvider
{
    /// <inheritdoc/>
    ModProviderMetaData IModProvider.MetaData { get; } = new()
    {
        ProviderId = "proxy",
        ProviderName = "Mod Providers Proxy",
        Icon = null,
        IsLocal = false,
    };

    /// <inheritdoc/>
    Task<AbstractModDetails> IModProvider.GetModDetailAsync(string slug)
    {
        throw new ProxyCantExecuteException();
    }

    /// <inheritdoc/>
    async Task<List<AbstractModVersion>> IModProvider.GetModVersionsAsync(string slug, EnumModLoader[]? modLoaders, string[]? gameVersions)
    {
        List<AbstractModVersion> lists = new();
        foreach (var modProvider in this.Providers)
        {
            lists.AddRange(await modProvider.GetModVersionsAsync(slug, modLoaders, gameVersions));
        }

        return lists;
    }

    /// <inheritdoc/>
    string IModProvider.OriginUrl(string slug) => throw new ProxyCantExecuteException();

    /// <inheritdoc/>
    async Task<List<AbstractModSearchResult>> IModProvider.SearchModAsync(string? modName, int limit, int offset, EnumSearchSortRule order, string[]? gameVersions, EnumModLoader[]? modLoaders)
    {
        var lists = new List<AbstractModSearchResult>();
        foreach (var modProvider in this.Providers)
        {
            lists.AddRange(await modProvider.SearchModAsync(modName, limit, offset, order, gameVersions, modLoaders));
        }

        return lists;
    }
}
