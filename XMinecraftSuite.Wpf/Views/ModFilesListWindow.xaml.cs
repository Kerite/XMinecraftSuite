using System.Windows;
using XMinecraftSuite.Wpf.ViewModels;

namespace XMinecraftSuite.Wpf.Views;

/// <summary>
///     ModFilesListWindow.xaml 的交互逻辑
/// </summary>
public partial class ModVersionsListWindow : Window
{
    #region Constructors
    public ModVersionsListWindow(string slug)
    {
        InitializeComponent();
        ViewModel = new ModVersionsWindowViewModel(slug)
        {
            IsActive = true
        };
        DataContext = ViewModel;
    }
    #endregion

    public ModVersionsWindowViewModel ViewModel { get; }
}
