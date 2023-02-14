using System.Diagnostics;

namespace XMinecraftSuite.Core.Models.Abstracts
{
    [DebuggerDisplay("Filename = {Filename}")]
    public abstract class AbstractModFile
    {
        public abstract string Filename { get; }
        public abstract string DownloadUrl { get; }
        public abstract string Hash { get; }
        public abstract bool Primary { get; }
    }
}
