using System;
using System.Globalization;
using System.Windows.Data;

namespace XMinecraftSuite.Wpf.Converters
{
    public class SelectableItemColorConverter : IMultiValueConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? Constants.SelectedItemBrush : Constants.TransparentBrush;
            }
            else if (value is string strValue1 && parameter is string strValue2)
            {
                return strValue1 == strValue2 ? Constants.SelectedItemBrush : Constants.TransparentBrush;
            }

            return Constants.TransparentBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2)
            {
                return values[0] == values[1] ? Constants.SelectedItemBrush : Constants.TransparentBrush;
            }

            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}