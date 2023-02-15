using System.Globalization;
using System.Net.Cache;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace XMinecraftSuite.Wpf.Converters;

public class BitmapImageConverter : TypedValueConverter<string, ImageSource?>
{
    public int? Height { get; set; }
    public int? Width { get; set; }
    public BitmapImage? FallbackImage { get; set; }

    #region 方法 Methods
    protected override ImageSource? NewConvert(string source, Type targetType, object parameter, CultureInfo culture)
    {
        if (string.IsNullOrEmpty(source))
            return FallbackImage;
        var bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.UriSource = new Uri(source);
        bitmap.UriCachePolicy = new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable);
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        if (Height is not null) bitmap.DecodePixelHeight = (int)Height;
        if (Width is not null) bitmap.DecodePixelWidth = (int)Width;
        bitmap.EndInit();
        return bitmap;
    }

    protected override string NewConvertBack(ImageSource? back, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    #endregion
}
