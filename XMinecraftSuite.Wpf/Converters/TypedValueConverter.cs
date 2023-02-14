using CommunityToolkit.Diagnostics;
using System.Globalization;

namespace XMinecraftSuite.Wpf.Converters
{
    public abstract class TypedValueConverter<TSource, TTarget> : BaseValueConverter
    {
        #region 方法 Methods
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((targetType != typeof(TTarget)) || (value is not TSource))
            {
                ThrowHelper.ThrowArgumentException("value");
            }
            return NewConvert((TSource)value, targetType, parameter, culture)!;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((targetType != typeof(TSource)) || (value is not TTarget))
            {
                ThrowHelper.ThrowArgumentException("value");
            }
            return NewConvertBack((TTarget)value, targetType, parameter, culture)!;
        }
        #endregion

        protected abstract TTarget NewConvert(TSource source, Type targetType, object parameter, CultureInfo culture);
        protected abstract TSource NewConvertBack(TTarget back, Type targetType, object parameter, CultureInfo culture);
    }
}
