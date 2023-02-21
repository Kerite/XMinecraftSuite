// Copyright (c) Keriteal. All rights reserved.

using System.Globalization;
using System.Windows;

namespace XMinecraftSuite.Wpf.Converters;

/// <summary>
/// 将可空的值转换为Visibility.
/// </summary>
public class NullableToVisibilityConverter : BaseValueConverter
{
    /// <summary>
    /// 是否倒置.
    /// </summary>
    public bool IsReserve { get; set; }

    /// <summary>
    /// 使用<see cref="Visibility.Collapsed"/> 而不是 <see cref="Visibility.Hidden"/>.
    /// </summary>
    public bool UseCollapse { get; set; }

    /// <inheritdoc/>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var boolValue = value is not null;
        if (this.IsReserve)
        {
            boolValue = !boolValue;
        }

        if (boolValue)
        {
            return Visibility.Visible;
        }

        return this.UseCollapse ? Visibility.Collapsed : Visibility.Hidden;
    }

    /// <inheritdoc/>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
