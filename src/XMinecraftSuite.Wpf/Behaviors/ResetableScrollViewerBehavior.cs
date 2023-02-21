// Copyright (c) Keriteal. All rights reserved.

using System.Windows;
using System.Windows.Controls;

namespace XMinecraftSuite.Wpf.Behaviors;

/// <summary>
/// 可重置的ScrollViewer.
/// </summary>
public static class ResetableScrollViewerBehavior
{
    /// <summary>
    /// 绑定到的属性.
    /// </summary>
    public static readonly DependencyProperty AutoScrollToTopProperty = DependencyProperty.RegisterAttached(
        "AutoScrollToTop", typeof(bool), typeof(ResetableScrollViewerBehavior), new PropertyMetadata(false, (o, e) =>
        {
            if (o is not ScrollViewer scrollViewer)
            {
                return;
            }

            if (!(bool)e.NewValue)
            {
                return;
            }

            scrollViewer.ScrollToTop();
            SetAutoScrollToTop(o, false);
        }));

    /// <summary>
    /// d.
    /// </summary>
    /// <param name="obj">a.</param>
    /// <returns>c.</returns>
    public static bool GetAutoScrollToTop(DependencyObject obj)
    {
        return (bool)obj.GetValue(AutoScrollToTopProperty);
    }

    /// <summary>
    /// d.
    /// </summary>
    /// <param name="obj">a.</param>
    /// <param name="value">c.</param>
    public static void SetAutoScrollToTop(DependencyObject obj, bool value)
    {
        obj.SetValue(AutoScrollToTopProperty, value);
    }
}
