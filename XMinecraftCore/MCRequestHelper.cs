using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core
{
    public class MCRequestHelper
    {
        public bool UseHmclApi = false;
        public static readonly MCRequestHelper Instance = new();

        public static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
        {
            Converters =
            {
                new JsonStringEnumConverter(new SnakeCaseNamingPolicy())
            }
        };

        #region HttpClient

        private static readonly HttpClient officialClient = new()
        {
            BaseAddress = new Uri("http://launchermeta.mojang.com/")
        };

        private static readonly HttpClient hmclApiClient = new()
        {
            BaseAddress = new Uri("https://bmclapi2.bangbang93.com/")
        };

        static MCRequestHelper()
        {
            officialClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            hmclApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private HttpClient currentClient => UseHmclApi ? hmclApiClient : officialClient;

        #endregion HttpClient

        #region 获取MC版本列表

        public async Task<string[]> GetMinecraftVersionsStringAsync(bool includeSnapshotAndLegacy)
        {
            return (await GetMinecraftVersionsModelAsync(includeSnapshotAndLegacy))
                .Select(versionModel => versionModel.Id)
                .ToArray();
        }

        public async Task<List<MinecraftVersionModel>> GetMinecraftVersionsModelAsync(bool includeSnapshotAndLegacy)
        {
            var responseMessage = await currentClient.GetAsync("mc/game/version_manifest_v2.json");

            if (!responseMessage.IsSuccessStatusCode) throw new Exception("Request Minecraft Version Failed");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();

            if (jsonString == null) throw new Exception("Json Content is Null");
            var versionsJson = JsonNode.Parse(jsonString)?["versions"]?.AsArray();

            if (versionsJson == null) throw new Exception("Parse Version List Json Failed");

            return versionsJson
                .Select(version => version.Deserialize<MinecraftVersionModel>(jsonSerializerOptions))
                // 包括快照
                .Where(versionModel =>
                {
                    if (versionModel == null) return false;
                    return includeSnapshotAndLegacy || (versionModel.Type == EnumVersionType.Release);
                })
                .ToList()!;
        }

        #endregion 获取MC版本列表

        public async Task<byte[]> GetOptifineDownloadUrl(string mcVersion, string patch)
        {
            var request = await hmclApiClient.GetAsync($"optifine/{mcVersion}/HD_U/{patch}");
            throw new NotImplementedException();
        }

        public async Task<OptifineVersionModel[]> GetOptifineVersionsAsync(string mcVersion)
        {
            var request = await hmclApiClient.GetAsync($"optifine/{mcVersion}");
            throw new NotImplementedException();
        }
    }
}