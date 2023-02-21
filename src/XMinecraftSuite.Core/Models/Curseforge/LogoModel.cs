// Copyright (c) Keriteal. All rights reserved.

namespace XMinecraftSuite.Core.Models.Curseforge;

/// <summary>
/// CurseForge Mod 的 Logo.
/// </summary>
public sealed class LogoModel
{
    /// <summary>
    /// Logo的Id.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Logo的缩略图Url.
    /// </summary>
    public string ThumbnailUrl { get; init; } = string.Empty;
}
