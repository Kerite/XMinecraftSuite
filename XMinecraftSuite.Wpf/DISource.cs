using System.Windows.Markup;

namespace XMinecraftSuite.Wpf;

public sealed class DISource : MarkupExtension
{
    public static Func<Type, object?> Resolver { get; set; } = (_) => null;

    public Type Type { get; set; } = typeof(object);

    public override object? ProvideValue(IServiceProvider serviceProvider)
    {
        return Resolver?.Invoke(Type);
    }
}
