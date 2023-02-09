using XMinecraftSuite.Core.Commons;
using XMinecraftSuite.Core.Excceptions;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;
using XMinecraftSuite.Core.Providers.Mod;

namespace XMinecraftSuite.Core.Providers;

public sealed class GlobalModProviderProxy : ViewModelBase, IModProvider
{
    public static GlobalModProviderProxy Instance { get; } = new();
    public ModProviderProxy OnlineProviderProxy { get; } = new();
    public ModProviderProxy LocalProviderProxy { get; } = new();
    public ModProviderMetaData MetaData { get; } = new("global", "Global Provider Proxy");

    static GlobalModProviderProxy()
    {
        Instance.Register(new ModrinthProvider());
    }

    public void Register(IModProvider modProvider)
    {
        this[modProvider.MetaData] = modProvider;
    }

    public IModProvider this[string key]
    {
        get => OnlineProviderProxy[key] ?? LocalProviderProxy[key];
        set
        {
            if (value.MetaData.IsLocal)
            {
                LocalProviderProxy[key] = value;
            }
            else
            {
                OnlineProviderProxy[key] = value;
            }
        }
    }

    public IModProvider this[ModProviderMetaData metaData]
    {
        get => this[metaData.ProviderId];
        set => this[metaData.ProviderId] = value;
    }

    async Task<List<AbstractModSearchResult>> IModProvider.Search(string? modName, int limit, int offset,
        SearchSortRule order, string[]? gameVersions, EnumModLoader[]? modLoaders)
    {
        var lists = new List<AbstractModSearchResult>();
        lists.AddRange(await ((IModProvider)LocalProviderProxy).Search(modName, limit, offset, order, gameVersions, modLoaders));
        lists.AddRange(await ((IModProvider)OnlineProviderProxy).Search(modName, limit, offset, order, gameVersions, modLoaders));

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
        lists.AddRange(await ((IModProvider)LocalProviderProxy).ModVersions(slug, modLoaders, gameVersions));
        lists.AddRange(await ((IModProvider)OnlineProviderProxy).ModVersions(slug, modLoaders, gameVersions));

        return lists;
    }

    string IModProvider.OriginUrl(string slug)
    {
        throw new ProxyCantExecuteException();
    }
}