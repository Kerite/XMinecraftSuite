using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Abstracts
{
    public class AbstractModSearchResult
    {
        public virtual string Name { get; }
        public virtual string Author { get; }
        public virtual string ImageUrl { get; }
        public virtual string Description { get; }
        public virtual string[] Categories { get; }

        /// <summary>
        /// 支持的游戏版本列表
        /// </summary>
        /// <returns></returns>
        public virtual string[] SupportedVersions { get; }

        public virtual EnumModLoader[] ModLoaders { get; }
        public virtual string LatestGameVersion { get; }
        public virtual string ModSource { get; }
        public virtual string Slug { get; }
    }
}