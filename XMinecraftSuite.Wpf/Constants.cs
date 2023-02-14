using System.Windows;
using System.Windows.Media;

namespace XMinecraftSuite.Wpf
{
    public sealed class Constants : ResourceDictionary
    {
        public static readonly Uri DefaultUri = new("about:blank");
        public static readonly Brush HoveredItemBrush = new SolidColorBrush(Color.FromRgb(0xF0, 0xF8, 0xFF));
        public static readonly Brush SelectedItemBrush = new SolidColorBrush(Color.FromRgb(0xCB, 0xE8, 0xF6));
        public static readonly Brush TransparentBrush = new SolidColorBrush(Colors.Transparent);

        public Constants()
        {
            Add("TransparentBrush", TransparentBrush);
            Add("SelectedItemBrush", SelectedItemBrush);
            Add("HoveredItemBrush", HoveredItemBrush);
        }
    }
}
