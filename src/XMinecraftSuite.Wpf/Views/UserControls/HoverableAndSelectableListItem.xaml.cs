// Copyright (c) Keriteal. All rights reserved.

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace XMinecraftSuite.Wpf.Views.UserControls;

/// <summary>
/// HoverableAndSelectableListItem.xaml 的交互逻辑.
/// </summary>
[ContentProperty("InnerContent")]
public partial class HoverableAndSelectableListItem : UserControl
{
    /// <summary>
    /// <see cref="CommandParameter"/> 的依赖属性.
    /// </summary>
    public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
        nameof(CommandParameter), typeof(object), typeof(HoverableAndSelectableListItem));

    /// <summary>
    /// <see cref="Command"/> 的依赖属性.
    /// </summary>
    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(HoverableAndSelectableListItem), new PropertyMetadata(null));

    /// <summary>
    /// <see cref="InnerContent"/> 的依赖属性.
    /// </summary>
    public static readonly DependencyProperty InnerContentProperty = DependencyProperty.Register(nameof(InnerContent), typeof(object), typeof(HoverableAndSelectableListItem), new PropertyMetadata(null));

    /// <summary>
    /// <see cref="Key"/> 的依赖属性.
    /// </summary>
    public static readonly DependencyProperty KeyProperty = DependencyProperty.Register(nameof(Key), typeof(string), typeof(HoverableAndSelectableListItem), new PropertyMetadata(string.Empty));

    /// <summary>
    /// <see cref="SelectedKey"/> 的依赖属性.
    /// </summary>
    public static readonly DependencyProperty SelectedKeyProperty = DependencyProperty.Register(nameof(SelectedKey), typeof(string), typeof(HoverableAndSelectableListItem), new PropertyMetadata(null));

    /// <summary>
    /// Initializes a new instance of the <see cref="HoverableAndSelectableListItem"/> class.
    /// </summary>
    public HoverableAndSelectableListItem()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 选择时执行的命令.
    /// </summary>
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    /// <summary>
    /// 执行命令时传递的参数.
    /// </summary>
    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandProperty, value);
    }

    /// <summary>
    /// 内部的内容.
    /// </summary>
    public object InnerContent
    {
        get => GetValue(InnerContentProperty);
        set => SetValue(InnerContentProperty, value);
    }

    /// <summary>
    /// 被选择的Key.
    /// </summary>
    public string SelectedKey
    {
        get => (string)GetValue(KeyProperty);
        set => SetValue(KeyProperty, value);
    }

    /// <summary>
    /// 当前元素的Key.
    /// </summary>
    public string Key
    {
        get => (string)GetValue(SelectedKeyProperty);
        set => SetValue(SelectedKeyProperty, value);
    }
}
