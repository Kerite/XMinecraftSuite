// Copyright (c) Keriteal. All rights reserved.

using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace XMinecraftSuite.Wpf.Converters;

/// <summary>
/// 如果为空，则可视，否则不可视.
/// </summary>
public class VisibleOrNullConverter : IValueConverter
{
    /// <inheritdoc/>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return (bool)(parameter ?? true) ? Visibility.Hidden : Visibility.Collapsed;
        }

        return Visibility.Visible;
    }

    /// <inheritdoc/>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
