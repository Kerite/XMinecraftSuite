using System.Diagnostics;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Core.Models.Abstracts
{
    [DebuggerDisplay("Name = {Name}")]
    public abstract class AbstractModVersion
    {
        public abstract string ChangeLog { get; }
        public abstract string Name { get; }
        public abstract string Number { get; }
        public abstract string ProjectId { get; }
        public abstract string VersionId { get; }
        public abstract int Downloads { get; }
        public abstract EnumModVersionType ModVersionType { get; }
        public abstract DateTime PublishedTime { get; }
        public abstract string[] GameVersions { get; }
        public abstract AbstractModDependency[] ModDependencies { get; }
        public abstract AbstractModFile[] ModFiles { get; }
        public abstract EnumModLoader[] ModLoaders { get; }
    }
}
