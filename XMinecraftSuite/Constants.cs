using System;
using System.Windows;
using System.Windows.Media;

namespace XMinecraftSuite.Wpf
{
    public sealed class Constants : ResourceDictionary
    {
        public static Brush TransparentBrush = new SolidColorBrush(Colors.Transparent);
        public static Brush SelectedItemBrush = new SolidColorBrush(Color.FromRgb(0xCB, 0xE8, 0xF6));
        public static Brush HoveredItemBrush = new SolidColorBrush(Color.FromRgb(0xF0, 0xF8, 0xFF));
        public static Uri DefaultUri = new Uri("about:blank");

        public Constants()
        {
            Add("TransparentBrush", TransparentBrush);
            Add("SelectedItemBrush", SelectedItemBrush);
            Add("HoveredItemBrush", HoveredItemBrush);
        }

        public static string[] DesignDatas = new string[]
        {
            "ok", "2", "3", "4", "5", "6",
            "ok", "2", "3", "4", "5", "6", "ok", "2", "3", "4", "5", "6", "ok", "2", "3", "4", "5", "6", "ok", "2", "3",
            "4", "5", "6",
        };
    }
}