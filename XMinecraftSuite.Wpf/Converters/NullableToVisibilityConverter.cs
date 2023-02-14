using System.Globalization;
using System.Windows;

namespace XMinecraftSuite.Wpf.Converters
{
    /// <summary>
    /// 默认情况下 当参数为 null 时不可见
    /// </summary>
    public class NullableToVisibilityConverter : BaseValueConverter
    {
        public bool IsReserve { get; set; }
        public bool UseCollapse { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = value is not null;
            if (IsReserve)
            {
                boolValue = !boolValue;
            }
            if (boolValue)
                return Visibility.Visible;
            return UseCollapse ? Visibility.Collapsed : Visibility.Hidden;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
