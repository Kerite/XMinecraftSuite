using System.Drawing;

namespace XMinecraftSuite.Core.Models
{
    [Serializable]
    public sealed class ModProviderMetaData : IEquatable<ModProviderMetaData>
    {
        public string ProviderId { get; private set; }
        public string ProviderName { get; private set; }
        public string? ApiBaseUrl { get; private set; }
        public Bitmap? Icon { get; private set; }
        public bool IsLocal { get; private set; }

        public ModProviderMetaData(string id, string providerName, string? baseUrl = null, Bitmap? icon = null,
            bool isLocal = false)
        {
            ProviderId = id;
            ApiBaseUrl = baseUrl;
            Icon = icon;
            IsLocal = isLocal;
            ProviderName = providerName;
        }

        public bool Equals(ModProviderMetaData? other)
        {
            if (other == null) return false;
            return other.ProviderId == this.ProviderId;
        }

        public override bool Equals(object? obj)
        {
            if (obj is ModProviderMetaData anotherMetaData)
            {
                return anotherMetaData.ProviderId == this.ProviderId;
            }

            return false;
        }
    }
}