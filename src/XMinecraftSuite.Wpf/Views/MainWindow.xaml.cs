// Copyright (c) Keriteal. All rights reserved.

using System.Windows;
using XMinecraftSuite.Gui.ViewModels;

namespace XMinecraftSuite.Wpf.Views;

/// <summary>
///     MainWindow.xaml 的交互逻辑.
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    /// <param name="viewModel">MainWindowViewModel.</param>
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        this.ViewModel = viewModel;
    }

    /// <summary>
    /// 主窗口 ViewModel.
    /// </summary>
    public MainWindowViewModel ViewModel { get; }
}
