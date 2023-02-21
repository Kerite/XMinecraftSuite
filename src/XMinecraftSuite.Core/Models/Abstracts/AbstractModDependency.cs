// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics;

namespace XMinecraftSuite.Core.Models.Abstracts;

/// <summary>
/// Mod 依赖项.
/// </summary>
[DebuggerDisplay("ProjectId = {ProjectId}")]
public abstract class AbstractModDependency
{
    /// <summary>
    /// 依赖项的ProjectId.
    /// </summary>
    public abstract string ProjectId { get; }

    /// <summary>
    /// 是否为必须的依赖.
    /// </summary>
    public abstract bool Required { get; }
}
