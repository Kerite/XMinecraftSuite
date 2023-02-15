using SkiaSharp;

namespace XMinecraftSuite.Core.Models;

[Serializable]
public sealed class ModProviderMetaData : IEquatable<ModProviderMetaData>
{
    public required string ProviderId { get; init; }
    public required string ProviderName { get; init; }
    public required bool IsLocal { get; init; } = true;
    public required SKBitmap? Icon { get; init; }

    public bool Equals(ModProviderMetaData? other)
    {
        if (other == null)
            return false;
        return other.ProviderId == ProviderId;
    }

    public override bool Equals(object? obj)
    {
        if (obj is ModProviderMetaData anotherMetaData)
            return anotherMetaData.ProviderId == ProviderId;
        return false;
    }

    public static SKBitmap LoadBitmapImage(Type type, string resourceKey)
    {
        var assembly = type.Assembly;
        using var stream = assembly.GetManifestResourceStream(resourceKey);
        return SKBitmap.Decode(stream);
    }
}
