// Copyright (c) Keriteal. All rights reserved.

using System.Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace XMinecraftSuite.Wpf.Converters;

/// <summary>
/// 通用的类型转换器.
/// </summary>
public class UniversalTypeConverter : IValueConverter
{
    /// <inheritdoc/>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Bitmap bitmapValue && targetType == typeof(BitmapSource))
        {
            return Imaging.CreateBitmapSourceFromHBitmap(bitmapValue.GetHbitmap(), nint.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        if (value is string && targetType == typeof(Uri))
        {
            return new Uri(string.Empty);
        }

        return value;
    }

    /// <inheritdoc/>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
