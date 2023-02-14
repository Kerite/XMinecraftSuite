using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;
using XMinecraftSuite.Core.Models.Modrinth;
using XMinecraftSuite.Core.Properties;

namespace XMinecraftSuite.Core.Providers.Mod
{
    public class ModrinthProvider : IModProvider
    {
        #region 静态属性
        private static readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://api.modrinth.com/v2/"),
        };
        private static readonly ModProviderMetaData metaData = new(
            "modrinth",
            "Modrinth",
            "https://api.modrinth.com/v2/",
            Resources.Modrinth,
            false);

        static ModrinthProvider()
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        public ModProviderMetaData MetaData => metaData;

        #region 显式接口实现 
        async Task<AbstractModDetails> IModProvider.GetModDetailAsync(string slug)
        {
            var response = await httpClient.GetAsync($"project/{slug}");
            if (!response.IsSuccessStatusCode)
                throw new Exception();
            var json = await response.Content.ReadAsStringAsync();
            var resultJson = JsonSerializer.Deserialize<ModrinthProjectJson>(json);
            return resultJson!;
        }

        async Task<List<AbstractModVersion>> IModProvider.GetModVersionsAsync(
            string slug,
            EnumModLoader[]? modLoaders,
            string[]? gameVersions)
        {
            var queryStr = $"project/{slug}/version";
            if (modLoaders != null)
            {
                var loadersFilter = string.Join(
                    ",",
                    modLoaders.Select(modLoader => $"\"{modLoader.ToString().ToLower()}\""));
                queryStr += $"?loaders=[{loadersFilter}]";
            }
            if (gameVersions != null)
            {
                var gameVersionFilter = string.Join(",", gameVersions.Select(gameVersion => $"\"{gameVersion}\""));
                queryStr += $"&game_versions=[{gameVersionFilter}]";
            }
            var response = await httpClient.GetAsync(queryStr);
            if (!response.IsSuccessStatusCode)
                throw new Exception();
            var json = await response.Content.ReadAsStringAsync();
            var jsonResult = JsonSerializer.Deserialize<ModrinthModVersion[]>(json);
            return jsonResult?.ToList<AbstractModVersion>() ?? new List<AbstractModVersion>();
        }

        string IModProvider.OriginUrl(string slug)
        {
            throw new NotImplementedException();
        }

        async Task<List<AbstractModSearchResult>> IModProvider.SearchModAsync(
            string? modName,
            int limit,
            int offset,
            SearchSortRule order,
            string[]? gameVersions,
            EnumModLoader[]? modLoaders)
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
            if (order != SearchSortRule.None)
            {
                queryParameters += "&index=";
                queryParameters += order switch
                {
                    SearchSortRule.Relevance => "relevance",
                    SearchSortRule.Downloads => "downloads",
                    SearchSortRule.Follows => "follows",
                    SearchSortRule.Newest => "newest",
                    SearchSortRule.Updated => "updated",
                    _ => string.Empty
                };
            }
            var response = await httpClient.GetAsync($"search{queryParameters}");
            if (!response.IsSuccessStatusCode)
                throw new Exception("Request Failed");
            var json = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonNode.Parse(json);
            if (jsonObject?["hits"] == null)
                throw new Exception("Response Body Is Not A Valid Json");
            var hitsList = jsonObject["hits"]!.AsArray();
            return hitsList?.AsEnumerable()
                    .Select(
                        result => (AbstractModSearchResult)JsonSerializer.Deserialize<ModrinthSearchResult>(
                                result!.ToJsonString())!)
                    .ToList() ??
                new();
        }
        #endregion

        private string GetDependencyFromVersionId(string version)
        {
            throw new NotImplementedException();
        }
    }
}
