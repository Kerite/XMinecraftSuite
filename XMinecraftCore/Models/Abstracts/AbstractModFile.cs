namespace XMinecraftSuite.Core.Models.Abstracts
{
    public abstract class AbstractModFile
    {
        public abstract string FileName { get; }
        public abstract string DownloadUrl { get; }

        public abstract string Hash { get; }
        public abstract bool Primary { get; }
    }
}