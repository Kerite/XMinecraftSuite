// Copyright (c) Keriteal. All rights reserved.

using System.Globalization;
using System.Windows;

namespace XMinecraftSuite.Wpf.Converters;

/// <summary>
/// 转换布尔值为 <see cref="Visibility"/>.
/// </summary>
public class BooleanToVisibilityConverter : TypedValueConverter<bool, Visibility>
{
    /// <summary>
    /// 倒置结果.
    /// </summary>
    public bool IsReserve { get; set; }

    /// <summary>
    /// 返回 <see cref="Visibility.Hidden"/> 而不是 <see cref="Visibility.Collapsed"/>.
    /// </summary>
    public bool UseHidden { get; set; }

    /// <inheritdoc/>
    protected override Visibility NewConvert(bool source, object parameter, CultureInfo culture)
    {
        var boolValue = System.Convert.ToBoolean(source, culture);
        if (this.IsReserve)
        {
            boolValue = !boolValue;
        }

        if (boolValue)
        {
            return Visibility.Visible;
        }

        return this.UseHidden ? Visibility.Hidden : Visibility.Collapsed;
    }

    /// <inheritdoc/>
    protected override bool NewConvertBack(Visibility back, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
