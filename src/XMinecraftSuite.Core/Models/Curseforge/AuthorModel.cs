// Copyright (c) Keriteal. All rights reserved.

namespace XMinecraftSuite.Core.Models.Curseforge;

/// <summary>
/// .
/// </summary>
public sealed class AuthorModel
{
    /// <summary>
    /// 作者ID.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// 作者名字.
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// 作者Url.
    /// </summary>
    public string Url { get; init; } = string.Empty;
}
