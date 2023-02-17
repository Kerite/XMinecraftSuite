using System.Windows;
using XMinecraftSuite.Gui.ViewModels;

namespace XMinecraftSuite.Wpf.Views;

/// <summary>
///     ModFilesListWindow.xaml 的交互逻辑
/// </summary>
public partial class ModVersionsListWindow : Window
{
    public delegate ModVersionsListWindow ModVersionsListWindowFactory(string key);

    public ModVersionsWindowViewModel ViewModel { get; }

    public ModVersionsListWindow(ModVersionsWindowViewModel.ModVersionsWindowViewModelFactory factory, string slug)
    {
        InitializeComponent();
        ViewModel = factory(slug);
        DataContext = ViewModel;
    }
}
