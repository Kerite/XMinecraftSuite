// Copyright (c) Keriteal. All rights reserved.

using System.Windows;
using System.Windows.Controls;

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
    }
}
