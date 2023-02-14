using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Abstracts
{
    public abstract class AbstractModSearchResult
    {
        public abstract string Author { get; }
        public abstract string Description { get; }
        public abstract string ImageUrl { get; }
        public abstract string LatestGameVersion { get; }
        public abstract string ModSource { get; }
        public abstract string Name { get; }
        public abstract string Slug { get; }
        public abstract string[] Categories { get; }
        public abstract EnumModLoader[] ModLoaders { get; }
        public abstract string[] SupportedVersions { get; }
    }
}
