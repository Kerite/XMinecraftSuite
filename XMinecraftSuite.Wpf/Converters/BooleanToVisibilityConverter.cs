using System.Globalization;
using System.Windows;

namespace XMinecraftSuite.Wpf.Converters;

public class BooleanToVisibilityConverter : BaseValueConverter
{
    public bool IsReserve { get; set; }
    public bool UseHidden { get; set; }

    #region 方法 Methods
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var boolValue = System.Convert.ToBoolean(value);
        if (IsReserve) boolValue = !boolValue;
        if (boolValue)
            return Visibility.Visible;
        return UseHidden ? Visibility.Hidden : Visibility.Collapsed;
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    #endregion
}
