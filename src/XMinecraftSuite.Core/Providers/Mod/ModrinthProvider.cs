// Copyright (c) Keriteal. All rights reserved.

using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using CommunityToolkit.Diagnostics;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;
using XMinecraftSuite.Core.Models.Modrinth;
using XMinecraftSuite.Core.Properties;

namespace XMinecraftSuite.Core.Providers.Mod;

internal class ModrinthProvider : IModProvider
{
    private static readonly HttpClient apiClient = new() { BaseAddress = new Uri("https://api.modrinth.com/v2/") };

    static ModrinthProvider()
    {
        apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public ModProviderMetaData MetaData => new()
    {
        ProviderId = "modrinth",
        ProviderName = "Modrinth",
        IsLocal = false,
        Icon = Utils.LoadBitmap(Resources.Modrinth),
    };

    async Task<AbstractModDetails> IModProvider.GetModDetailAsync(string slug)
    {
        var response = await apiClient.GetAsync($"project/{slug}");

        Guard.IsTrue(response.IsSuccessStatusCode);

        var json = await response.Content.ReadAsStringAsync();
        var resultJson = JsonSerializer.Deserialize<ModrinthProjectJson>(json);
        return resultJson!;
    }

    async Task<List<AbstractModVersion>> IModProvider.GetModVersionsAsync(string slug, EnumModLoader[]? modLoaders, string[]? gameVersions)
    {
        var queryStr = $"project/{slug}/version";
        if (modLoaders != null)
        {
            var loadersFilter = string.Join(
                ",", modLoaders.Select(modLoader => $"\"{modLoader.ToString().ToLower()}\""));
            queryStr += $"?loaders=[{loadersFilter}]";
        }

        if (gameVersions != null)
        {
            var gameVersionFilter = string.Join(",", gameVersions.Select(gameVersion => $"\"{gameVersion}\""));
            queryStr += $"&game_versions=[{gameVersionFilter}]";
        }

        var response = await apiClient.GetAsync(queryStr);

        Guard.IsTrue(response.IsSuccessStatusCode);

        var json = await response.Content.ReadAsStringAsync();
        var jsonResult = JsonSerializer.Deserialize<ModrinthModVersion[]>(json);
        return jsonResult?.ToList<AbstractModVersion>() ?? new List<AbstractModVersion>();
    }

    string IModProvider.OriginUrl(string slug)
    {
        return $"https://modrinth.com/mod/{slug}";
    }

    async Task<List<AbstractModSearchResult>> IModProvider.SearchModAsync(string? modName, int limit, int offset, EnumSearchSortRule order, string[]? gameVersions, EnumModLoader[]? modLoaders)
    {
        var queryParameters = "?";
        var limitStr = "40";
        if (limit != 0)
        {
            limitStr = limit.ToString();
        }

        queryParameters += $"limit={limitStr}&offset={offset}";
        if (modName != null)
        {
            queryParameters += $"&query={modName}";
        }

        if (order != EnumSearchSortRule.None)
        {
            queryParameters += "&index=";
            queryParameters += order switch
            {
                EnumSearchSortRule.Relevance => "relevance",
                EnumSearchSortRule.Downloads => "downloads",
                EnumSearchSortRule.Follows => "follows",
                EnumSearchSortRule.Newest => "newest",
                EnumSearchSortRule.Updated => "updated",
                _ => string.Empty,
            };
        }

        var response = await apiClient.GetAsync($"search{queryParameters}");

        Guard.IsTrue(response.IsSuccessStatusCode);

        var json = await response.Content.ReadAsStringAsync();
        var jsonObject = JsonNode.Parse(json);

        Guard.IsNotNull(jsonObject?["hits"]);

        var hitsList = jsonObject["hits"]!.AsArray();
        return hitsList.AsEnumerable()
            .Select(result =>
            {
                var deserialized = JsonSerializer.Deserialize<ModrinthSearchResult>(result!.ToJsonString());
                Guard.IsNotNull(deserialized);
                return deserialized;
            })
            .ToList<AbstractModSearchResult>();
    }
}
