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
public class MCRequestHelper
{
    /// <summary>
    /// 单例.
    /// </summary>
    public static readonly MCRequestHelper Instance = new();

    public bool UseHmclApi { get; set; } = false;

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        Converters = { new JsonStringEnumConverter(new SnakeCaseNamingPolicy()) },
    };

    private static readonly HttpClient HmclApiClient = new()
    {
        BaseAddress = new Uri("https://bmclapi2.bangbang93.com/"),
    };

    private static readonly HttpClient OfficialClient = new()
    {
        BaseAddress = new Uri("http://launchermeta.mojang.com/"),
    };

    static MCRequestHelper()
    {
        OfficialClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HmclApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    private HttpClient CurrentClient => UseHmclApi ? HmclApiClient : OfficialClient;

    public async Task<List<MinecraftVersionModel>> GetMinecraftVersionsModelAsync(bool includeSnapshotAndLegacy)
    {
        var responseMessage = await CurrentClient.GetAsync("mc/game/version_manifest_v2.json");
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception("Request Minecraft Version Failed");
        }

        var jsonString = await responseMessage.Content.ReadAsStringAsync();
        Guard.IsNotNullOrEmpty(jsonString);

        var versionsJson = JsonNode.Parse(jsonString)?["versions"]?.AsArray();
        if (versionsJson == null)
            throw new Exception("Parse Version List Json Failed");
        return versionsJson.Select(version => version.Deserialize<MinecraftVersionModel>(JsonSerializerOptions))
            .Where(versionModel =>
            {
                if (versionModel == null)
                    return false;
                return includeSnapshotAndLegacy || versionModel.Type == EnumVersionType.Release;
            })
            .ToList()!;
    }

    public async Task<string[]> GetMinecraftVersionsStringAsync(bool includeSnapshotAndLegacy)
    {
        return (await GetMinecraftVersionsModelAsync(includeSnapshotAndLegacy)).Select(versionModel => versionModel.Id)
            .ToArray();
    }

    public async Task<byte[]> GetOptifineDownloadUrlAsync(string mcVersion, string patch)
    {
        var request = await HmclApiClient.GetAsync($"optifine/{mcVersion}/HD_U/{patch}");
        throw new NotImplementedException();
    }

    public async Task<OptifineVersionModel[]> GetOptifineVersionsAsync(string mcVersion)
    {
        var request = await HmclApiClient.GetAsync($"optifine/{mcVersion}");
        throw new NotImplementedException();
    }
}
