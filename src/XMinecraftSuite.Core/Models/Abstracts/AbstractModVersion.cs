// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Abstracts;

/// <summary>
/// 抽象的 Mod 版本.
/// </summary>
[DebuggerDisplay("Name = {Name}")]
public abstract class AbstractModVersion
{
    /// <summary>
    /// 更新日志.
    /// </summary>
    public abstract string ChangeLog { get; }

    /// <summary>
    /// 版本名.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// 版本号.
    /// </summary>
    public abstract string Number { get; }

    /// <summary>
    /// 项目 ID.
    /// </summary>
    public abstract string ProjectId { get; }

    /// <summary>
    /// 版本 ID.
    /// </summary>
    public abstract string VersionId { get; }

    /// <summary>
    /// 下载量.
    /// </summary>
    public abstract int Downloads { get; }

    /// <summary>
    /// Mod 版本类型.
    /// </summary>
    public abstract EnumModVersionType ModVersionType { get; }

    /// <summary>
    /// 版本发布时间.
    /// </summary>
    public abstract DateTime PublishedTime { get; }

    /// <summary>
    /// 游戏版本.
    /// </summary>
    public abstract string[] GameVersions { get; }

    /// <summary>
    /// Mod 依赖.
    /// </summary>
    public abstract AbstractModDependency[] ModDependencies { get; }

    /// <summary>
    /// Mod 文件.
    /// </summary>
    public abstract AbstractModFile[] ModFiles { get; }

    /// <summary>
    /// 支持的 Mod 加载器.
    /// </summary>
    public abstract EnumModLoader[] ModLoaders { get; }
}
