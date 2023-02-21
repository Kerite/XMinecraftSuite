// Copyright (c) Keriteal. All rights reserved.

using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace XMinecraftSuite.Wpf.Converters;

/// <summary>
/// 数值转换器基类.
/// </summary>
public abstract class BaseValueConverter : MarkupExtension, IValueConverter
{
    /// <inheritdoc/>
    public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

    /// <inheritdoc/>
    public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

    /// <inheritdoc/>
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}
