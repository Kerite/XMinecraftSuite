using System.Net.Http.Headers;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Providers.Mod;

internal class CurseforgeProvider : IModProvider
{
    public static readonly string CurseforgeMinecraftId = "432";

    private static readonly HttpClient httpClient = new() { BaseAddress = new Uri("https://api.curseforge.com/v1") };

    static CurseforgeProvider()
    {
        httpClient.DefaultRequestHeaders.Add("x-api-key",
            "$2a$10$m9CWCHAby3Eq/DVGqBaaGe1AlMKFB3G4Z9K7yvZHbHxZTLpzO5TuC");
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    ModProviderMetaData IModProvider.MetaData => throw new NotImplementedException();

    public Task<List<AbstractModVersion>> GetModVersionsAsync(string slug, EnumModLoader[]? modLoaders = null,
        string[]? gameVersions = null)
    {
        throw new NotImplementedException();
    }

    Task<AbstractModDetails> IModProvider.GetModDetailAsync(string slug)
    {
        throw new NotImplementedException();
    }

    string IModProvider.OriginUrl(string slug)
    {
        throw new NotImplementedException();
    }

    public Task<List<AbstractModSearchResult>> SearchModAsync(string? modName = null, int limit = 0, int offset = 0,
        SearchSortRule order = SearchSortRule.None, string[]? gameVersions = null, EnumModLoader[]? modLoaders = null)
    {
        throw new NotImplementedException();
    }
}
