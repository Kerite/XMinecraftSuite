// Copyright (c) Keriteal. All rights reserved.

using SixLabors.ImageSharp;

namespace XMinecraftSuite.Core.Models;

/// <summary>
/// ModProvider 的 元数据.
/// </summary>
[Serializable]
[ToString]
[Equals(DoNotAddEqualityOperators = true)]
public sealed class ModProviderMetaData
{
    /// <summary>
    /// Provider 的 Id.
    /// </summary>
    public required string ProviderId { get; init; }

    /// <summary>
    /// Provider 的 名称.
    /// </summary>
    public required string ProviderName { get; init; }

    /// <summary>
    /// 数据是否来自本地.
    /// </summary>
    public required bool IsLocal { get; init; } = true;

    /// <summary>
    /// Provider 的图标.
    /// </summary>
    public required Image? Icon { get; init; }
}
