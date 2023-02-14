using System.Net.Http.Headers;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Providers.Mod
{
    public class CurseforgeProvider : IModProvider
    {
        public static string CurseforgeMinecraftId = "432";
        private static readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://api.curseforge.com/v1")
        };

        #region Constructors
        static CurseforgeProvider()
        {
            httpClient.DefaultRequestHeaders.Add("x-api-key",
                "$2a$10$m9CWCHAby3Eq/DVGqBaaGe1AlMKFB3G4Z9K7yvZHbHxZTLpzO5TuC");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(
                "application/json"));
        }
        #endregion

        public Task<List<AbstractModVersion>> GetModVersionsAsync(string slug, EnumModLoader[]? modLoaders,
            string[]? gameVersions = null)
        {
            throw new NotImplementedException();
        }

        ModProviderMetaData IModProvider.MetaData => throw new NotImplementedException();

        Task<AbstractModDetails> IModProvider.GetModDetailAsync(string slug)
        {
            throw new NotImplementedException();
        }

        string IModProvider.OriginUrl(string slug)
        {
            throw new NotImplementedException();
        }

#pragma warning disable CS8769 // 参数“modLoaders”类型中引用类型的为 Null 性与实现的成员“Task<List<AbstractModSearchResult>> IModProvider.SearchModAsync(string? modName = null, int limit = 0, int offset = 0, SearchSortRule order = SearchSortRule.None, string[]? gameVersions = null, EnumModLoader[]? modLoaders = null)”不匹配(可能是由于为 Null 性特性)。
#pragma warning disable CS1066 // 为形参“offset”指定的默认值将不起任何作用，因为它适用于在不允许指定可选实参的上下文中使用的成员
#pragma warning disable CS8769 // 参数“gameVersions”类型中引用类型的为 Null 性与实现的成员“Task<List<AbstractModSearchResult>> IModProvider.SearchModAsync(string? modName = null, int limit = 0, int offset = 0, SearchSortRule order = SearchSortRule.None, string[]? gameVersions = null, EnumModLoader[]? modLoaders = null)”不匹配(可能是由于为 Null 性特性)。
#pragma warning disable CS1066 // 为形参“limit”指定的默认值将不起任何作用，因为它适用于在不允许指定可选实参的上下文中使用的成员
#pragma warning disable CS8769 // 参数“modname”类型中引用类型的为 Null 性与实现的成员“Task<List<AbstractModSearchResult>> IModProvider.SearchModAsync(string? modName = null, int limit = 0, int offset = 0, SearchSortRule order = SearchSortRule.None, string[]? gameVersions = null, EnumModLoader[]? modLoaders = null)”不匹配(可能是由于为 Null 性特性)。
        Task<List<AbstractModSearchResult>> IModProvider.SearchModAsync(string modname, int limit = 0, int offset = 0,
#pragma warning restore CS8769 // 参数“modname”类型中引用类型的为 Null 性与实现的成员“Task<List<AbstractModSearchResult>> IModProvider.SearchModAsync(string? modName = null, int limit = 0, int offset = 0, SearchSortRule order = SearchSortRule.None, string[]? gameVersions = null, EnumModLoader[]? modLoaders = null)”不匹配(可能是由于为 Null 性特性)。
#pragma warning restore CS1066 // 为形参“limit”指定的默认值将不起任何作用，因为它适用于在不允许指定可选实参的上下文中使用的成员
#pragma warning restore CS8769 // 参数“gameVersions”类型中引用类型的为 Null 性与实现的成员“Task<List<AbstractModSearchResult>> IModProvider.SearchModAsync(string? modName = null, int limit = 0, int offset = 0, SearchSortRule order = SearchSortRule.None, string[]? gameVersions = null, EnumModLoader[]? modLoaders = null)”不匹配(可能是由于为 Null 性特性)。
#pragma warning restore CS1066 // 为形参“offset”指定的默认值将不起任何作用，因为它适用于在不允许指定可选实参的上下文中使用的成员
#pragma warning restore CS8769 // 参数“modLoaders”类型中引用类型的为 Null 性与实现的成员“Task<List<AbstractModSearchResult>> IModProvider.SearchModAsync(string? modName = null, int limit = 0, int offset = 0, SearchSortRule order = SearchSortRule.None, string[]? gameVersions = null, EnumModLoader[]? modLoaders = null)”不匹配(可能是由于为 Null 性特性)。
#pragma warning disable CS1066 // 为形参“order”指定的默认值将不起任何作用，因为它适用于在不允许指定可选实参的上下文中使用的成员
            SearchSortRule order = SearchSortRule.None,
#pragma warning restore CS1066 // 为形参“order”指定的默认值将不起任何作用，因为它适用于在不允许指定可选实参的上下文中使用的成员
#pragma warning disable CS8625 // 无法将 null 字面量转换为非 null 的引用类型。
#pragma warning disable CS1066 // 为形参“modLoaders”指定的默认值将不起任何作用，因为它适用于在不允许指定可选实参的上下文中使用的成员
#pragma warning disable CS8625 // 无法将 null 字面量转换为非 null 的引用类型。
#pragma warning disable CS1066 // 为形参“gameVersions”指定的默认值将不起任何作用，因为它适用于在不允许指定可选实参的上下文中使用的成员
            string[] gameVersions = null, EnumModLoader[] modLoaders = null)
#pragma warning restore CS1066 // 为形参“gameVersions”指定的默认值将不起任何作用，因为它适用于在不允许指定可选实参的上下文中使用的成员
#pragma warning restore CS8625 // 无法将 null 字面量转换为非 null 的引用类型。
#pragma warning restore CS1066 // 为形参“modLoaders”指定的默认值将不起任何作用，因为它适用于在不允许指定可选实参的上下文中使用的成员
#pragma warning restore CS8625 // 无法将 null 字面量转换为非 null 的引用类型。
        {
            throw new NotImplementedException();
        }
    }
}