// Copyright (c) Keriteal. All rights reserved.

using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using CommunityToolkit.Diagnostics;

namespace XMinecraftSuite.Wpf.Converters;

/// <summary>
/// 指定输入输出类型的 <see cref="IValueConverter"/> 和 <see cref="MarkupExtension"/>.
/// </summary>
/// <typeparam name="TSource">输入的类型.</typeparam>
/// <typeparam name="TTarget">输出的类型.</typeparam>
public abstract class TypedValueConverter<TSource, TTarget> : BaseValueConverter
{
    /// <inheritdoc/>
    public sealed override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (targetType != typeof(TTarget) || value is not TSource)
        {
            ThrowHelper.ThrowArgumentException("value");
        }

        return NewConvert((TSource)value, parameter, culture)!;
    }

    /// <inheritdoc/>
    public sealed override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (targetType != typeof(TSource) || value is not TTarget)
        {
            ThrowHelper.ThrowArgumentException("value");
        }

        return NewConvertBack((TTarget)value, parameter, culture)!;
    }

    /// <summary>
    /// 进行转换的实际操作.
    /// </summary>
    /// <param name="source">输入的值.</param>
    /// <param name="parameter">参数.</param>
    /// <param name="culture">地区信息.</param>
    /// <returns>输出的值.</returns>
    protected abstract TTarget NewConvert(TSource source, object parameter, CultureInfo culture);

    /// <summary>
    /// 将输出转换回输入.
    /// </summary>
    /// <param name="back">需要反向转换的值.</param>
    /// <param name="parameter">参数.</param>
    /// <param name="culture">地区信息.</param>
    /// <returns>原始值.</returns>
    protected abstract TSource NewConvertBack(TTarget back, object parameter, CultureInfo culture);
}
