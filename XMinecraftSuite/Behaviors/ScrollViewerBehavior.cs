using System.Windows;
using System.Windows.Controls;

namespace XMinecraftSuite.Wpf.Behaviors;

public static class ScrollViewerBehavior
{
    public static bool GetAutoScrollToTop(DependencyObject obj)
    {
        return (bool)obj.GetValue(AutoScrollToTopProperty);
    }

    public static void SetAutoScrollToTop(DependencyObject obj, bool value)
    {
        obj.SetValue(AutoScrollToTopProperty, value);
    }

    public static readonly DependencyProperty AutoScrollToTopProperty =
        DependencyProperty.RegisterAttached(
            "AutoScrollToTop",
            typeof(bool),
            typeof(ScrollViewerBehavior),
            new PropertyMetadata(
                false,
                (o, e) =>
                {
                    if (o is not ScrollViewer scrollViewer)
                    {
                        return;
                    }

                    if (!(bool)e.NewValue)
                        return;

                    scrollViewer.ScrollToTop();
                    SetAutoScrollToTop(o, false);
                }
            )
        );
}
