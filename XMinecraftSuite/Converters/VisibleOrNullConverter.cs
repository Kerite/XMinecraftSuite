using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace XMinecraftSuite.Wpf.Converters
{
    /// <summary>
    /// 如果为空，则可视，否则不可视
    /// </summary>
    public class VisibleOrNullConverter : IValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter">isCollapsed</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return (bool)(parameter ?? true) ? Visibility.Hidden : Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}