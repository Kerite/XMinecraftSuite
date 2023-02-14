using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Abstracts
{
    public abstract class AbstractModDetails
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public abstract DateTime Created { get; }
        /// <summary>
        /// Mod 详情
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// 下载量
        /// </summary>
        public abstract int Downloads { get; }
        /// <summary>
        /// 关注者
        /// </summary>
        public abstract int Followers { get; }
        /// <summary>
        /// 支持的游戏版本
        /// </summary>
        public abstract string[] GameVersions { get; }
        /// <summary>
        /// 图像的Url
        /// </summary>
        public abstract string ImageUrl { get; }
        /// <summary>
        /// Issues 链接
        /// </summary>
        public abstract string Issues { get; }
        /// <summary>
        /// Mod 名字
        /// </summary>
        public abstract string Name { get; }
        public abstract string OriginUrl { get; }
        public abstract string ShortDescription { get; }
        public abstract EnumModSide Side { get; }
        /// <summary>
        /// 代码链接
        /// </summary>
        public abstract string Source { get; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public abstract DateTime Updated { get; }
        /// <summary>
        /// Wiki 链接
        /// </summary>
        public abstract string Wiki { get; }
    }
}
