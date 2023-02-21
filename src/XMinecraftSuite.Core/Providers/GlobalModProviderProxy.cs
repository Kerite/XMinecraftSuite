// Copyright (c) Keriteal. All rights reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using XMinecraftSuite.Core.Exceptions;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;
using XMinecraftSuite.Core.Providers.Mod;

namespace XMinecraftSuite.Core.Providers;

/// <summary>
/// ModProvider代理，包括本地和联机.
/// </summary>
public sealed class GlobalModProviderProxy : ObservableRecipient, IModProvider
{
    static GlobalModProviderProxy() => Instance.Register(new ModrinthProvider());

    /// <summary>
    /// 单例的实例.
    /// </summary>
    public static GlobalModProviderProxy Instance { get; } = new();

    /// <summary>
    /// 本地 ModProvider 代理.
    /// </summary>
    public ModProviderProxy LocalProviderProxy { get; } = new();

    /// <summary>
    /// 在线 ModProvider 代理.
    /// </summary>
    public ModProviderProxy OnlineProviderProxy { get; } = new();

    /// <inheritdoc/>
    public ModProviderMetaData MetaData { get; } = new()
    {
        IsLocal = false,
        ProviderId = "global",
        ProviderName = "Global Mod Provider",
        Icon = null,
    };

    /// <summary>
    /// 根据 Key 增加或者设置Provider.
    /// </summary>
    /// <param name="key">Provider's key.</param>
    /// <returns>Provider.</returns>
    public IModProvider? this[string? key]
    {
        get => this.OnlineProviderProxy[key] ?? this.LocalProviderProxy[key];
        set
        {
            if (value?.MetaData.IsLocal ?? true)
            {
                this.LocalProviderProxy[key] = value;
            }
            else
            {
                this.OnlineProviderProxy[key] = value;
            }
        }
    }

    /// <summary>
    /// 根据MetaData增加或者设置Provider.
    /// </summary>
    /// <param name="metaData">Provider's MetaData.</param>
    /// <returns>Provider.</returns>
    public IModProvider? this[ModProviderMetaData metaData]
    {
        get => this[metaData.ProviderId];
        set => this[metaData.ProviderId] = value;
    }

    /// <inheritdoc/>
    Task<AbstractModDetails> IModProvider.GetModDetailAsync(string slug) => throw new ProxyCantExecuteException();

    /// <inheritdoc/>
    async Task<List<AbstractModVersion>> IModProvider.GetModVersionsAsync(string slug, EnumModLoader[]? modLoaders, string[]? gameVersions)
    {
        List<AbstractModVersion> lists = new();
        lists.AddRange(await ((IModProvider)this.LocalProviderProxy).GetModVersionsAsync(slug, modLoaders, gameVersions));
        lists.AddRange(await ((IModProvider)this.OnlineProviderProxy).GetModVersionsAsync(slug, modLoaders, gameVersions));
        return lists;
    }

    /// <inheritdoc/>
    string IModProvider.OriginUrl(string slug) => throw new ProxyCantExecuteException();

    /// <inheritdoc/>
    async Task<List<AbstractModSearchResult>> IModProvider.SearchModAsync(string? modName, int limit, int offset, EnumSearchSortRule order, string[]? gameVersions, EnumModLoader[]? modLoaders)
    {
        var lists = new List<AbstractModSearchResult>();
        lists.AddRange(await ((IModProvider)this.LocalProviderProxy).SearchModAsync(modName, limit, offset, order, gameVersions, modLoaders));
        lists.AddRange(await ((IModProvider)this.OnlineProviderProxy).SearchModAsync(modName, limit, offset, order, gameVersions, modLoaders));
        return lists;
    }

    /// <summary>
    /// 注册Provider.
    /// </summary>
    /// <param name="modProvider">注册的Provider.</param>
    public void Register(IModProvider modProvider) => this[modProvider.MetaData] = modProvider;
}
