// Copyright (c) Keriteal. All rights reserved.

using System.Windows.Markup;

namespace XMinecraftSuite.Wpf;

/// <summary>
/// 便于依赖注入的 MarkupExtension.
/// </summary>
public sealed class DISource : MarkupExtension
{
    /// <summary>
    /// 生成.
    /// </summary>
    public static Func<Type, object?> Resolver { get; set; } = (_) => null;

    /// <summary>
    /// 返回的类型.
    /// </summary>
    public Type Type { get; set; } = typeof(object);

    /// <inheritdoc/>
    public override object? ProvideValue(IServiceProvider serviceProvider)
    {
        return Resolver?.Invoke(this.Type);
    }
}
