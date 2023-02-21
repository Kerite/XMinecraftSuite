// Copyright (c) Keriteal. All rights reserved.

using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Abstracts;

/// <summary>
/// 抽象的 Mod 搜索结果.
/// </summary>
public abstract class AbstractModSearchResult
{
    /// <summary>
    /// 作者.
    /// </summary>
    public abstract string Author { get; }

    /// <summary>
    /// 介绍.
    /// </summary>
    public abstract string Description { get; }

    /// <summary>
    /// 图像 Url.
    /// </summary>
    public abstract string ImageUrl { get; }

    /// <summary>
    /// 最近的游戏版本.
    /// </summary>
    public abstract string LatestGameVersion { get; }

    /// <summary>
    /// Mod 来源.
    /// </summary>
    public abstract string ModSource { get; }

    /// <summary>
    /// Mod 名字.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Mod 的 Slug.
    /// </summary>
    public abstract string Slug { get; }

    /// <summary>
    /// 关键字.
    /// </summary>
    public abstract string[] Categories { get; }

    /// <summary>
    /// Mod 加载器.
    /// </summary>
    public abstract EnumModLoader[] ModLoaders { get; }

    /// <summary>
    /// 支持的版本.
    /// </summary>
    public abstract string[] SupportedVersions { get; }
}
