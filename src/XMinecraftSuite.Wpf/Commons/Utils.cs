﻿using System.Windows;
using System.Windows.Controls;

namespace XMinecraftSuite.Wpf.Commons
{
    public static class Utils
    {
        #region 方法 Methods
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
        #endregion
    }
}