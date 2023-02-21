// Copyright (c) Keriteal. All rights reserved.

using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Abstracts;

/// <summary>
/// Mod详情Model.
/// </summary>
public abstract class AbstractModDetails
{
    /// <summary>
    /// Mod的Slug.
    /// </summary>
    public abstract string Slug { get; }

    /// <summary>
    /// 创建时间.
    /// </summary>
    public abstract DateTime Created { get; }

    /// <summary>
    /// Mod 详情.
    /// </summary>
    public abstract string Description { get; }

    /// <summary>
    /// 下载量.
    /// </summary>
    public abstract int Downloads { get; }

    /// <summary>
    /// 关注者.
    /// </summary>
    public abstract int Followers { get; }

    /// <summary>
    /// 支持的游戏版本.
    /// </summary>
    public abstract string[] GameVersions { get; }

    /// <summary>
    /// 图像的Url.
    /// </summary>
    public abstract string ImageUrl { get; }

    /// <summary>
    /// Issues 链接.
    /// </summary>
    public abstract string Issues { get; }

    /// <summary>
    /// Mod 名字.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// 原始Url.
    /// </summary>
    public abstract string OriginUrl { get; }

    /// <summary>
    /// 短的Mod介绍.
    /// </summary>
    public abstract string ShortDescription { get; }

    /// <summary>
    /// Mod需求的加载位置.
    /// </summary>
    public abstract EnumModSide Side { get; }

    /// <summary>
    /// 代码链接.
    /// </summary>
    public abstract string Source { get; }

    /// <summary>
    /// 更新时间.
    /// </summary>
    public abstract DateTime Updated { get; }

    /// <summary>
    /// Wiki 链接.
    /// </summary>
    public abstract string Wiki { get; }
}
