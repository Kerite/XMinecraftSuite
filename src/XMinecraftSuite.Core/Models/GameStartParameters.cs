namespace XMinecraftSuite.Core.Models;

public class GameStartParameters
{
    public string Username { get; set; }
    public string Version { get; set; }
    public DirectoryInfo GameDir { get; set; } = new(".");
    public DirectoryInfo AssetDir { get; set; }
    public string AssetIndex { get; set; }
    public string Uuid { get; set; }
    public string AccessToken { get; set; }
    public string ClientId { get; set; }
    public string Xuid { get; set; }
    public string UserType { get; set; }
    public string VersionType { get; set; }

    public string? Server { get; set; }
    public int Port { get; set; } = 25565;
    public DirectoryInfo? ResourcePackDir { get; set; }

    public string? ProxyHost { get; set; }
    public int ProxyPort { get; set; }
    public string? ProxyUsername { get; set; }
    public string? ProxyPassword { get; set; }

    public int Width { get; set; } = 854;
    public int Height { get; set; } = 480;

    public bool FullScreen { get; set; } = false;
    public int FullScreenWidth { get; set; }
    public int FUllScreenHeight { get; set; }

    public string[] ToCliWrapArguments()
    {
        var args = new[]
        {
            "--username", Username, //
            "--version", Version, //
            "--gameDir", GameDir.FullName, //
            "--assetsDir", AssetDir.FullName, //
            "--assetIndex", AssetIndex, //
            "--uuid", Uuid, //
            "--accessToken", AccessToken, //
            "--userType", UserType, //
            "--versionType", VersionType, //
            "--width", Width.ToString(), //
            "--height", Height.ToString() //
        }.ToList();
        if (Server != null)
        {
            args.AddRange(new[]
            {
                "--server", Server, //
                "--port", Port.ToString() //
            });
        }

        if (ProxyHost != null)
        {
            args.AddRange(new[]
            {
                "--proxyHost", ProxyHost, //
                "--proxyPort", ProxyPort.ToString() //
            });
            if (ProxyUsername != null)
            {
                args.AddRange(new[]
                {
                    "--proxyUser", ProxyUsername //
                });
            }

            if (ProxyPassword != null)
            {
                args.AddRange(new[]
                {
                    "--proxyPass", ProxyPassword //
                });
            }
        }

        if (FullScreen)
        {
            args.AddRange(new[]
            {
                "--fullscreenWidth", FullScreenWidth.ToString(), //
                "--fullscreenHeight", FUllScreenHeight.ToString() //
            });
        }

        return args.ToArray();
    }
}
