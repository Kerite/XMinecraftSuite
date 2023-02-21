// Copyright (c) Keriteal. All rights reserved.

namespace XMinecraftSuite.Core.Models.Enums;

/// <summary>
/// Mod加载的位置.
/// </summary>
public enum EnumModSide
{
    /// <summary>
    /// 服务端Mod.
    /// </summary>
    ServerSide,

    /// <summary>
    /// 客户端Mod.
    /// </summary>
    ClientSide,

    /// <summary>
    /// 同时需要.
    /// </summary>
    Both,

    /// <summary>
    /// 任意一端.
    /// </summary>
    Optional,

    /// <summary>
    /// 未知.
    /// </summary>
    Unknown,
}
