using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace XMinecraftSuite.Wpf.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 转换布尔值为是否可视
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? Visibility.Visible : Visibility.Hidden;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                Visibility.Visible => true,
                Visibility.Hidden => false,
                Visibility.Collapsed => false,
                _ => DependencyProperty.UnsetValue
            };
        }
    }
}