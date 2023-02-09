using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Abstracts
{
    public abstract class AbstractModVersion
    {
        /// <summary>
        /// 模组版本名
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// 模组版本号
        /// </summary>
        public abstract string Number { get; }

        /// <summary>
        /// 版本发布时间
        /// </summary>
        public abstract DateTime PublishedTime { get; }

        /// <summary>
        /// Mod 这个版本支持的游戏版本
        /// </summary>
        public abstract string[] GameVersions { get; }

        /// <summary>
        /// Mod加载器
        /// </summary>
        public abstract EnumModLoader[] ModLoaders { get; }

        /// <summary>
        /// Mod的文件
        /// </summary>
        public abstract AbstractModFile[] ModFiles { get; }
    }
}