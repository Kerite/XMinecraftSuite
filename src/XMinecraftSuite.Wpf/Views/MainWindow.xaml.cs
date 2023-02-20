using System.Windows;
using XMinecraftSuite.Gui.ViewModels;

namespace XMinecraftSuite.Wpf.Views;

/// <summary>
///     MainWindow.xaml 的交互逻辑
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
    }

    public MainWindowViewModel ViewModel { get; }
}
