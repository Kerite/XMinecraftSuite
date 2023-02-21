// Copyright (c) Keriteal. All rights reserved.

namespace XMinecraftSuite.Core.Models.Enums;

/// <summary>
/// 搜索结果排序规则.
/// </summary>
public enum EnumSearchSortRule
{
    /// <summary>
    ///     不传递排序参数（默认）.
    /// </summary>
    None,

    /// <summary>
    ///     关联度.
    /// </summary>
    Relevance,

    /// <summary>
    ///     下载量.
    /// </summary>
    Downloads,

    /// <summary>
    ///     关注者.
    /// </summary>
    Follows,

    /// <summary>
    ///     最近创建.
    /// </summary>
    Newest,

    /// <summary>
    ///     最近更新.
    /// </summary>
    Updated,
}
