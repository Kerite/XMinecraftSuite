using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Providers.Mod
{
    /// <summary>
    /// Mod提供者
    /// </summary>
    public interface IModProvider
    {
        /// <summary>
        /// 返回Mod提供者的图标
        /// </summary>
        /// <returns></returns>
        public ModProviderMetaData MetaData { get; }

        /// <summary>
        /// 获取Mod详情
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public Task<AbstractModDetails> GetModDetailAsync(string slug);

        /// <summary>
        /// 获取Mod版本列表
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="modLoaders"></param>
        /// <param name="gameVersions"></param>
        /// <returns></returns>
        public Task<List<AbstractModVersion>> GetModVersionsAsync(
            string slug,
            EnumModLoader[]? modLoaders = null,
            string[]? gameVersions = null);

        /// <summary>
        /// 获取原始的网页
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public string OriginUrl(string slug);

        /// <summary>
        /// 搜索Mod
        /// </summary>
        /// <param name="modName">Mod名字</param>
        /// <param name="limit">每页数量</param>
        /// <param name="offset">页码</param>
        /// <param name="order">排序顺序</param>
        /// <param name="gameVersions">支持的游戏版本</param>
        /// <param name="modLoaders">Mod加载器</param>
        /// <returns></returns>
        public Task<List<AbstractModSearchResult>> SearchModAsync(
            string? modName = null,
            int limit = 0,
            int offset = 0,
            SearchSortRule order = SearchSortRule.None,
            string[]? gameVersions = null,
            EnumModLoader[]? modLoaders = null);
    }
}
