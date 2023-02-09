using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models
{
    [Serializable]
    public class CurseforgeSearchItem : AbstractModSearchResult
    {
        [JsonPropertyName("name")] public string Name_ { get; set; }

        [JsonPropertyName("slug")] public string Slug_ { get; set; }

        [JsonPropertyName("authors")] public AuthorModel[] Authors_ { get; set; }

        [JsonPropertyName("logo")] public LogoModel Logo_ { get; set; }

        [JsonPropertyName("summary")] public string Summary_ { get; set; }

        public override string Author => string.Join(", ", Authors_.Select(x => x.Name));

        public override string[] Categories => throw new NotImplementedException();

        public override string Description => Summary_;

        public override string Slug => Slug_;

        public override string ImageUrl => Logo_.ThumbnailUrl;

        public override string LatestGameVersion => throw new NotImplementedException();

        public override EnumModLoader[] ModLoaders => throw new NotImplementedException();

        public override string ModSource => "curseforge";

        public override string Name => Name_;

        public override string[] SupportedVersions => throw new NotImplementedException();
    }

    public sealed class AuthorModel
    {
        public int Id;
        public string Name;
        public string Url;
    }

    public sealed class LogoModel
    {
        public int Id;
        public string ThumbnailUrl;
    }

    public sealed class CategoryModel
    {
        public int Id;
        public string Name;
        public string Slug;
    }
}