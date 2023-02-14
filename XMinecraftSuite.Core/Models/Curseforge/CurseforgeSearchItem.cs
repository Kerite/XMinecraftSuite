using System.Diagnostics;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Curseforge
{
    [Serializable]
    public class CurseforgeSearchItem : AbstractModSearchResult
    {
        public override string Author => string.Join(", ", MAuthors.Select(x => x.Name));
        public override string[] Categories => throw new NotImplementedException();
        public override string Description => MSummary;
        public override string Slug => MSlug;
        public override string ImageUrl => MLogo.ThumbnailUrl;
        public override string LatestGameVersion => throw new NotImplementedException();
        public override EnumModLoader[] ModLoaders => throw new NotImplementedException();
        public override string ModSource => "curseforge";
        public override string Name => MName;
        public override string[] SupportedVersions => throw new NotImplementedException();

        [JsonPropertyName("authors")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public AuthorModel[] MAuthors { get; set; } = Array.Empty<AuthorModel>();

        [JsonPropertyName("logo")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public LogoModel MLogo { get; set; }

        [JsonPropertyName("name")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string MName { get; set; } = string.Empty;

        [JsonPropertyName("slug")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string MSlug { get; set; } = string.Empty;

        [JsonPropertyName("summary")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string MSummary { get; set; } = string.Empty;
    }
}
