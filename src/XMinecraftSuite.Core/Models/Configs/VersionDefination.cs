// Copyright (c) Keriteal. All rights reserved.

namespace XMinecraftSuite.Core.Models.Configs;

/// <summary>
/// 版本定义.
/// </summary>
public class VersionDefination
{
    /// <summary>
    /// 游戏目录，一般为.minecraft文件夹或者.minecraft/versions/.
    /// </summary>
    public required string GameDir { get; init; }

    /// <summary>
    /// 资源目录，一般为.minecraft/assets.
    /// </summary>
    public required string AssetsDir { get; init; }

    /// <summary>
    /// 资源包目录.
    /// </summary>
    public required string ResourcePackDir { get; set; }

    /// <summary>
    /// 窗体宽度，默认应该为854.
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    /// 窗体高度，默认应该为480.
    /// </summary>
    public int? Height { get; set; }
}
