using System.Net.Http.Headers;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Providers.Mod
{
    public class CurseforgeProvider : IModProvider
    {
        private static readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://api.curseforge.com/v1")
        };

        public static string CurseforgeMinecraftId = "432";

        ModProviderMetaData IModProvider.MetaData => throw new NotImplementedException();

        static CurseforgeProvider()
        {
            httpClient.DefaultRequestHeaders.Add("x-api-key",
                "$2a$10$m9CWCHAby3Eq/DVGqBaaGe1AlMKFB3G4Z9K7yvZHbHxZTLpzO5TuC");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(
                "application/json"));
        }

        Task<List<AbstractModSearchResult>> IModProvider.Search(string modname, int limit = 0, int offset = 0,
            SearchSortRule order = SearchSortRule.None,
            string[] gameVersions = null, EnumModLoader[] modLoaders = null)
        {
            throw new NotImplementedException();
        }

        Task<AbstractModDetailsResult> IModProvider.Details(string slug)
        {
            throw new NotImplementedException();
        }

        public Task<List<AbstractModVersion>> ModVersions(string slug, EnumModLoader[]? modLoaders,
            string[]? gameVersions = null)
        {
            throw new NotImplementedException();
        }

        string IModProvider.OriginUrl(string slug)
        {
            throw new NotImplementedException();
        }
    }
}