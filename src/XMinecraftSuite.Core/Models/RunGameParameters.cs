// Copyright (c) Keriteal. All rights reserved.

namespace XMinecraftSuite.Core.Models;

/// <summary>
/// 启动游戏需要的参数.
/// </summary>
[ToString]
public sealed class RunGameParameters
{
    /// <summary>
    /// 用户名.
    /// </summary>
    public string Username { get; init; } = "Steve";

    /// <summary>
    /// 版本.
    /// </summary>
    public required string Version { get; init; }

    /// <summary>
    /// 游戏目录.
    /// </summary>
    public DirectoryInfo GameDir { get; init; } = new(".");

    /// <summary>
    /// 资源目录.
    /// </summary>
    public DirectoryInfo? AssetDir { get; init; }

    /// <summary>
    /// 资源包目录.
    /// </summary>
    public DirectoryInfo? ResourcePackDir { get; init; }

    /// <summary>
    /// 资源索引 这个值为 <see cref="AssetDir">assets</see>/indexes/下的Json文件的名字.
    /// </summary>
    public required string AssetIndex { get; init; }

    /// <summary>
    /// UUID.
    /// </summary>
    public required string Uuid { get; init; }

    /// <summary>
    /// AccessToken.
    /// </summary>
    public required string AccessToken { get; init; }

    /// <summary>
    /// ClientID.
    /// </summary>
    public required string ClientId { get; init; }

    /// <summary>
    /// Xuid.
    /// </summary>
    public required string Xuid { get; init; }

    /// <summary>
    /// 用户类型 支持的值.
    /// </summary>
    public required string UserType { get; init; }

    /// <summary>
    /// 版本类型 (release).
    /// </summary>
    public string VersionType { get; init; } = "release";

    /// <summary>
    /// 打开时加入的服务器.
    /// </summary>
    public string? Server { get; init; }

    /// <summary>
    /// 加入的服务器的端口.
    /// </summary>
    public int Port { get; init; } = 25565;

    /// <summary>
    /// 游戏使用的代理.
    /// </summary>
    public string? ProxyHost { get; init; }

    /// <summary>
    /// 游戏使用的代理的端口.
    /// </summary>
    public int ProxyPort { get; init; }

    /// <summary>
    /// 代理身份认证的Username.
    /// </summary>
    public string? ProxyUsername { get; init; }

    /// <summary>
    /// 代理身份认证的密码.
    /// </summary>
    public string? ProxyPassword { get; init; }

    /// <summary>
    /// 游戏窗口宽度.
    /// </summary>
    public int Width { get; init; } = 854;

    /// <summary>
    /// 游戏窗口高度.
    /// </summary>
    public int Height { get; init; } = 480;

    /// <summary>
    /// 游戏是否全屏.
    /// </summary>
    public bool FullScreen { get; init; } = false;

    /// <summary>
    /// 游戏全屏宽度.
    /// </summary>
    public int FullScreenWidth { get; init; }

    /// <summary>
    /// 游戏全屏高度.
    /// </summary>
    public int FUllScreenHeight { get; init; }

    /// <summary>
    /// 转换到可以传递到 <see cref="CliWrap.Cli"/> 的参数列表.
    /// </summary>
    /// <returns>参数列表.</returns>
    public string[] ToCliWrapArguments()
    {
        var args = new[]
        {
            "--username", this.Username,
            "--version", this.Version,
            "--gameDir", this.GameDir.FullName,
            "--assetsDir", this.AssetDir?.FullName ?? "ok",
            "--assetIndex", this.AssetIndex,
            "--uuid", this.Uuid,
            "--accessToken", this.AccessToken,
            "--clientId", this.ClientId,
            "--xuid", this.Xuid,
            "--userType", this.UserType,
            "--versionType", this.VersionType,
            "--width", this.Width.ToString(),
            "--height", this.Height.ToString(),
        }.ToList();

        if (this.Server != null)
        {
            args.AddRange(new[]
            {
                "--server", this.Server,
                "--port", this.Port.ToString(),
            });
        }

        if (this.ProxyHost != null)
        {
            args.AddRange(new[]
            {
                "--proxyHost", this.ProxyHost,
                "--proxyPort", this.ProxyPort.ToString(),
            });
            if (this.ProxyUsername != null)
            {
                args.AddRange(new[]
                {
                    "--proxyUser", this.ProxyUsername,
                });
            }

            if (this.ProxyPassword != null)
            {
                args.AddRange(new[]
                {
                    "--proxyPass", this.ProxyPassword,
                });
            }
        }

        if (this.FullScreen)
        {
            args.AddRange(new[]
            {
                "--fullscreenWidth", this.FullScreenWidth.ToString(),
                "--fullscreenHeight", this.FUllScreenHeight.ToString(),
            });
        }

        return args.ToArray();
    }
}
