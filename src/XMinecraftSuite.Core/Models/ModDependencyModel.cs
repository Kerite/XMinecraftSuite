// Copyright (c) Keriteal. All rights reserved.

namespace XMinecraftSuite.Core.Models;

/// <summary>
/// Mod依赖项.
/// </summary>
[ToString]
public sealed class ModDependencyModel
{
    /// <summary>
    /// 依赖的Mod的名字.
    /// </summary>
    public string Name { get; } = string.Empty;

    /// <summary>
    /// 依赖的Mod的Slug.
    /// </summary>
    public string Slug { get; } = string.Empty;

    /// <summary>
    /// 依赖的最小版本.
    /// </summary>
    public string Version { get; } = string.Empty;
}
