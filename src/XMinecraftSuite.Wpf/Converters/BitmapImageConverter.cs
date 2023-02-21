// Copyright (c) Keriteal. All rights reserved.

using System.Globalization;
using System.Net.Cache;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace XMinecraftSuite.Wpf.Converters;

/// <summary>
/// 将 <see cref="string"/> 转换到 <see cref="ImageSource"/>.
/// </summary>
public class BitmapImageConverter : TypedValueConverter<string, ImageSource?>
{
    /// <summary>
    /// 需要的图像高度.
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    /// 需要的图像宽度.
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    /// 默认的图像.
    /// </summary>
    public BitmapImage? FallbackImage { get; set; }

    /// <inheritdoc/>
    protected override ImageSource? NewConvert(string source, object parameter, CultureInfo culture)
    {
        if (string.IsNullOrEmpty(source))
        {
            return this.FallbackImage;
        }

        var bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.UriSource = new Uri(source);
        bitmap.UriCachePolicy = new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable);
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        if (this.Height is not null)
        {
            bitmap.DecodePixelHeight = (int)this.Height;
        }

        if (this.Width is not null)
        {
            bitmap.DecodePixelWidth = (int)this.Width;
        }

        bitmap.EndInit();
        return bitmap;
    }

    /// <inheritdoc/>
    protected override string NewConvertBack(ImageSource? back, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
