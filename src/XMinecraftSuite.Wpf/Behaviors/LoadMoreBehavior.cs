// Copyright (c) Keriteal. All rights reserved.

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace XMinecraftSuite.Wpf.Behaviors;

/// <summary>
/// 让ScrollViewer支持加载更多.
/// </summary>
public sealed class LoadMoreBehavior : Behavior<ScrollViewer>
{
    /// <summary>
    /// <see cref="CommandParameter"/>的依赖属性.
    /// </summary>
    public static readonly DependencyProperty CommandParameterProperty =
        DependencyProperty.Register("CommandParameter", typeof(object), typeof(LoadMoreBehavior));

    /// <summary>
    /// <see cref="Command"/>的依赖属性.
    /// </summary>
    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(LoadMoreBehavior));

    /// <summary>
    /// Gets or sets 触发加载更多时执行的命令.
    /// </summary>
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    /// <summary>
    /// Gets 触发加载更多时传递的参数.
    /// </summary>
    public object? CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    /// <inheritdoc/>
    protected override void OnAttached()
    {
        this.AssociatedObject.ScrollChanged += ScrollChanged;
    }

    private void ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        if (e.VerticalChange <= 0)
        {
            return;
        }

        if (Math.Abs(e.VerticalOffset + e.ViewportHeight - e.ExtentHeight) < 0.001)
        {
            this.Command?.Execute(this.CommandParameter);
        }
    }
}
