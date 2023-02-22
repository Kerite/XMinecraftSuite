// Copyright (c) Keriteal. All rights reserved.

using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace XMinecraftSuite.Wpf.Commons
{
    /// <summary>
    /// 一些工具类.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// 将UserControl显示为窗口.
        /// </summary>
        /// <param name="userControl">被显示的UserControl.</param>
        /// <param name="title">窗体的标题.</param>
        public static void ShowUserControlAsWindow(UserControl userControl, string title = "")
        {
            var window = new Window
            {
                Title = title,
                Content = userControl,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
            };
            window.ShowDialog();
        }

        /// <summary>
        /// 转换 <see cref="Image{TPixel}"/> 到 <see cref="Bitmap"/>.
        /// </summary>
        /// <typeparam name="TPixel">Pixel Type.</typeparam>
        /// <param name="image">The source image.</param>
        /// <returns>A bitmap converted from <see cref="Image{TPixel}"/>.</returns>
        public static Bitmap ToBitmap<TPixel>(this Image<TPixel> image)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            using var memoryStream = new MemoryStream();
            var imageEncoder = image.GetConfiguration().ImageFormatsManager.FindEncoder(PngFormat.Instance);
            image.Save(memoryStream, imageEncoder);

            memoryStream.Seek(0, SeekOrigin.Begin);

            return new Bitmap(memoryStream);
        }

        /// <summary>
        /// 转换 <see cref="SixLabors.ImageSharp.Image"/> 到 <see cref="Bitmap"/>.
        /// </summary>
        /// <param name="image">The source image.</param>
        /// <returns>A bitmap converted from <see cref="Image{TPixel}"/>.</returns>
        public static Bitmap ToBitmap(this SixLabors.ImageSharp.Image image)
        {
            using var memoryStream = new MemoryStream();
            var imageEncoder = image.GetConfiguration().ImageFormatsManager.FindEncoder(PngFormat.Instance);
            image.Save(memoryStream, imageEncoder);

            memoryStream.Seek(0, SeekOrigin.Begin);

            return new Bitmap(memoryStream);
        }
    }
}
