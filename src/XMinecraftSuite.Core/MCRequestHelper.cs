// Copyright (c) Keriteal. All rights reserved.

using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using CommunityToolkit.Diagnostics;
using XMinecraftSuite.Core.JsonConverter;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core;

/// <summary>
///  用于访问MC相关API的帮助类.
/// </summary>
public sealed class MCRequestHelper
{
    /// <summary>
    /// 单例.
    /// </summary>
    public static readonly MCRequestHelper Instance = new();

    private static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        Converters = { new JsonStringEnumConverter(new SnakeCaseNamingPolicy()) },
    };

    private static readonly HttpClient bmclApiClient = new()
    {
        BaseAddress = new Uri("https://bmclapi2.bangbang93.com/"),
    };

    private static readonly HttpClient officialApiClient = new()
    {
        BaseAddress = new Uri("http://launchermeta.mojang.com/"),
    };

    static MCRequestHelper()
    {
        officialApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        bmclApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    /// <summary>
    /// 使用HmclApi.
    /// </summary>
    public bool UseHmclApi { get; set; } = false;

    private HttpClient CurrentClient => this.UseHmclApi ? bmclApiClient : officialApiClient;

    /// <summary>
    /// 获取 Minecraft 版本列表.
    /// </summary>
    /// <param name="includeSnapshotAndLegacy">包括快照和旧版.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<List<MinecraftVersionModel>> GetMinecraftVersionsModelAsync(bool includeSnapshotAndLegacy)
    {
        var responseMessage = await this.CurrentClient.GetAsync("mc/game/version_manifest_v2.json");

        Guard.IsTrue(responseMessage.IsSuccessStatusCode);
        var jsonString = await responseMessage.Content.ReadAsStringAsync();

        Guard.IsNotNullOrEmpty(jsonString);
        var versionsJson = JsonNode.Parse(jsonString)?["versions"]?.AsArray();

        Guard.IsNotNull(versionsJson);
        return versionsJson.Select(version => version.Deserialize<MinecraftVersionModel>(jsonSerializerOptions))
            .Where(versionModel =>
            {
                Guard.IsNotNull(versionModel);
                return includeSnapshotAndLegacy || versionModel.Type == EnumVersionType.Release;
            })
            .ToList()!;
    }

    /// <summary>
    /// 获取 Minecraft 游戏列表.
    /// </summary>
    /// <param name="includeSnapshotAndLegacy">包含快照.</param>
    /// <returns>Minecraft 版本列表.</returns>
    public async Task<string[]> GetMinecraftVersionsStringAsync(bool includeSnapshotAndLegacy)
    {
        return (await GetMinecraftVersionsModelAsync(includeSnapshotAndLegacy)).Select(versionModel => versionModel.Id)
            .ToArray();
    }

    /// <summary>
    /// 获取对应版本的 Optifine 的下载链接.
    /// </summary>
    /// <param name="mcVersion">Minecraft 版本.</param>
    /// <param name="patch">Optifine 的补丁版本号.</param>
    /// <returns>Optifine 下载 Url.</returns>
    public async Task<string> GetOptifineDownloadUrlAsync(string mcVersion, string patch)
    {
        _ = await bmclApiClient.GetAsync($"optifine/{mcVersion}/HD_U/{patch}");
        return string.Empty;
    }

    /// <summary>
    /// 获取 Optifine 版本列表.
    /// </summary>
    /// <param name="mcVersion">Minecraft 版本.</param>
    /// <returns>Optifine 版本列表.</returns>
    public async Task<OptifineVersionModel[]> GetOptifineVersionsAsync(string mcVersion)
    {
        _ = await bmclApiClient.GetAsync($"optifine/{mcVersion}");
        return Array.Empty<OptifineVersionModel>();
    }
}
