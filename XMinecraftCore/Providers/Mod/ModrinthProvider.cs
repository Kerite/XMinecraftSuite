using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Providers.Mod
{
    public class ModrinthProvider : IModProvider
    {
        private static readonly HttpClient HttpClient = new()
        {
            BaseAddress = new Uri("https://api.modrinth.com/v2/"),
        };

        public ModProviderMetaData MetaData { get; } =
            new("modrinth", "Modrinth", "https://api.modrinth.com/v2/", Properties.Resources.Modrinth, false);

        static ModrinthProvider()
        {
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        async Task<List<AbstractModSearchResult>> IModProvider.Search(string? modName, int limit, int offset,
            SearchSortRule order, string[]? gameVersions, EnumModLoader[]? modLoaders)
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
                queryParameters += "&query=" + modName;
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
                    _ => ""
                };
            }

            var response = await HttpClient.GetAsync("search" + queryParameters);

            if (!response.IsSuccessStatusCode) throw new Exception("Request Failed");

            var json = response.Content.ReadAsStringAsync().Result;
            var jsonObject = JsonNode.Parse(json);

            if (jsonObject?["hits"] == null) throw new Exception("Response Body Is Not A Valid Json");

            var hitsList = jsonObject["hits"]!.AsArray();

            return hitsList.AsEnumerable()
                .Select(result =>
                    (AbstractModSearchResult)JsonSerializer.Deserialize<ModrinthSearchResult>(result.ToJsonString()))
                .ToList();
        }

        async Task<AbstractModDetails> IModProvider.Details(string slug)
        {
            var response = await HttpClient.GetAsync($"project/{slug}");

            if (!response.IsSuccessStatusCode) throw new Exception();

            var json = response.Content.ReadAsStringAsync().Result;
            var resultJson = JsonSerializer.Deserialize<ModrinthProjectJson>(json);
            return resultJson!;
        }

        async Task<List<AbstractModVersion>> IModProvider.ModVersions(string slug, EnumModLoader[]? modLoaders,
            string[]? gameVersions = null)
        {
            var queryStr = $"project/{slug}/version";
            if (modLoaders != null)
            {
                var loadersFilter = string.Join(",",
                    modLoaders.Select(modLoader => $"\"{modLoader.ToString().ToLower()}\""));
                queryStr += $"?loaders=[{loadersFilter}]";
            }

            if (gameVersions != null)
            {
                var gameVersionFilter = string.Join(",", gameVersions.Select(gameVersion => $"\"{gameVersion}\""));
                queryStr += $"&game_versions=[{gameVersionFilter}]";
            }

            var response = await HttpClient.GetAsync(queryStr);
            if (!response.IsSuccessStatusCode) throw new Exception();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<AbstractModVersion>>(json) ?? new List<AbstractModVersion>();
        }

        string IModProvider.OriginUrl(string slug)
        {
            throw new NotImplementedException();
        }

        private string GetDependencyFromVersionId(string version)
        {
            throw new NotImplementedException();
        }
    }
}