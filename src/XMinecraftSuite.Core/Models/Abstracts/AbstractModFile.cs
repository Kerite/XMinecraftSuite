// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics;

namespace XMinecraftSuite.Core.Models.Abstracts;

/// <summary>
/// 抽象的 Mod 文件.
/// </summary>
[DebuggerDisplay("Filename = {Filename}")]
public abstract class AbstractModFile
{
    /// <summary>
    /// 文件名.
    /// </summary>
    public abstract string Filename { get; }

    /// <summary>
    /// 下载链接.
    /// </summary>
    public abstract string DownloadUrl { get; }

    /// <summary>
    /// 文件 Hash.
    /// </summary>
    public abstract string Hash { get; }

    /// <summary>
    /// 是否为首选.
    /// </summary>
    public abstract bool Primary { get; }
}
