// Copyright (c) Keriteal. All rights reserved.

using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace XMinecraftSuite.Wpf.Converters;

/// <summary>
/// 根据元素是否被选择返回颜色.
/// </summary>
public class SelectableItemColorConverter : IMultiValueConverter, IValueConverter
{
    /// <summary>
    /// 选择的元素的背景色.
    /// </summary>
    public Brush SelectedItemBrush { get; set; } = DefaultSelectedItemBrush;

    /// <summary>
    /// 没有被选择的元素的背景色.
    /// </summary>
    public Brush DefaultItemBrush { get; set; } = DefaultNotSelectedItemBrush;

    private static Brush DefaultSelectedItemBrush { get; } = new SolidColorBrush(Color.FromRgb(0xCB, 0xE8, 0xF6));

    private static Brush DefaultNotSelectedItemBrush { get; } = new SolidColorBrush(Colors.Transparent);

    /// <inheritdoc/>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return boolValue ? this.SelectedItemBrush : this.DefaultItemBrush;
        }
        else if (value is string strValue1 && parameter is string strValue2)
        {
            return strValue1 == strValue2 ? this.SelectedItemBrush : this.DefaultItemBrush;
        }
        else
        {
            return value == parameter;
        }
    }

    /// <inheritdoc/>
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length == 2)
        {
            return values[0] == values[1] ? this.SelectedItemBrush : this.DefaultItemBrush;
        }

        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
