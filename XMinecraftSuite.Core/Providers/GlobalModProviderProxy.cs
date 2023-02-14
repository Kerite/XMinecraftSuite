using CommunityToolkit.Mvvm.ComponentModel;
using XMinecraftSuite.Core.Exceptions;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;
using XMinecraftSuite.Core.Providers.Mod;

namespace XMinecraftSuite.Core.Providers
{
    public sealed class GlobalModProviderProxy : ObservableRecipient, IModProvider
    {

        #region 静态属性
        public static GlobalModProviderProxy Instance { get; } = new();
        #endregion

        public ModProviderProxy LocalProviderProxy { get; } = new();
        public ModProviderProxy OnlineProviderProxy { get; } = new();
        public ModProviderMetaData MetaData { get; } = new("global", "Global Provider Proxy");

        #region 方法Methods
        public void Register(IModProvider modProvider)
        {
            this[modProvider.MetaData] = modProvider;
        }
        #endregion

        public IModProvider? this[string? key]
        {
            get => OnlineProviderProxy[key] ?? LocalProviderProxy[key];
            set
            {
                if (value?.MetaData.IsLocal ?? true)
                {
                    LocalProviderProxy[key] = value;
                }
                else
                {
                    OnlineProviderProxy[key] = value;
                }
            }
        }

        public IModProvider? this[ModProviderMetaData metaData]
        {
            get => this[metaData.ProviderId];
            set => this[metaData.ProviderId] = value;
        }

        #region 显式接口实现 Explit interface implementor 
        Task<AbstractModDetails> IModProvider.GetModDetailAsync(string slug)
        {
            throw new ProxyCantExecuteException();
        }

        async Task<List<AbstractModVersion>> IModProvider.GetModVersionsAsync(
            string slug,
            EnumModLoader[]? modLoaders,
            string[]? gameVersions)
        {
            List<AbstractModVersion> lists = new();
            lists.AddRange(await ((IModProvider)LocalProviderProxy).GetModVersionsAsync(slug, modLoaders, gameVersions));
            lists.AddRange(
                await ((IModProvider)OnlineProviderProxy).GetModVersionsAsync(slug, modLoaders, gameVersions));
            return lists;
        }

        string IModProvider.OriginUrl(string slug)
        {
            throw new ProxyCantExecuteException();
        }

        async Task<List<AbstractModSearchResult>> IModProvider.SearchModAsync(
            string? modName,
            int limit,
            int offset,
            SearchSortRule order,
            string[]? gameVersions,
            EnumModLoader[]? modLoaders)
        {
            var lists = new List<AbstractModSearchResult>();
            lists.AddRange(
                await ((IModProvider)LocalProviderProxy).SearchModAsync(
                    modName,
                    limit,
                    offset,
                    order,
                    gameVersions,
                    modLoaders));
            lists.AddRange(
                await ((IModProvider)OnlineProviderProxy).SearchModAsync(
                    modName,
                    limit,
                    offset,
                    order,
                    gameVersions,
                    modLoaders));
            return lists;
        }
        #endregion

        #region Constructors
        static GlobalModProviderProxy()
        {
            Instance.Register(new ModrinthProvider());
        }

        private GlobalModProviderProxy() { }
        #endregion
    }
}
