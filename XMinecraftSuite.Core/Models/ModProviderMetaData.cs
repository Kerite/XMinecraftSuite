using SkiaSharp;

namespace XMinecraftSuite.Core.Models;

[Serializable]
[Equals(DoNotAddEqualityOperators = true)]
public sealed class ModProviderMetaData
{
    public required string ProviderId { get; init; }
    public required string ProviderName { get; init; }
    public required bool IsLocal { get; init; } = true;
    public required SKBitmap? Icon { get; init; }

    public static SKBitmap LoadBitmapImage(Type type, string resourceKey)
    {
        var assembly = type.Assembly;
        using var stream = assembly.GetManifestResourceStream(resourceKey);
        return SKBitmap.Decode(stream);
    }
}
