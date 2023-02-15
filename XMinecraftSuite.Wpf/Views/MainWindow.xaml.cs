using System.Windows;
using XMinecraftSuite.Wpf.ViewModels;

namespace XMinecraftSuite.Wpf.Views;

/// <summary>
///     MainWindow.xaml 的交互逻辑
/// </summary>
public partial class MainWindow : Window
{
    #region Constructors
    //Constructors
    public MainWindow()
    {
        InitializeComponent();
        DataContext = ViewModel;
    }
    #endregion

    public MainWindowViewModel ViewModel { get; } = new();
}
