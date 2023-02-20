// Copyright (c) Keriteal. All rights reserved.

using System.Globalization;
using CommunityToolkit.Diagnostics;

namespace XMinecraftSuite.Wpf.Converters;

public abstract class TypedValueConverter<TSource, TTarget> : BaseValueConverter
{
    /// <inheritdoc/>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (targetType != typeof(TTarget) || value is not TSource)
        {
            ThrowHelper.ThrowArgumentException("value");
        }

        return NewConvert((TSource)value, targetType, parameter, culture)!;
    }

    /// <inheritdoc/>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (targetType != typeof(TSource) || value is not TTarget)
        {
            ThrowHelper.ThrowArgumentException("value");
        }

        return NewConvertBack((TTarget)value, targetType, parameter, culture)!;
    }

    protected abstract TTarget NewConvert(TSource source, Type targetType, object parameter, CultureInfo culture);

    protected abstract TSource NewConvertBack(TTarget back, Type targetType, object parameter, CultureInfo culture);
}
