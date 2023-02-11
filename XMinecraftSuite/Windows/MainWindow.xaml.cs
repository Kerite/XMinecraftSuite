using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers.Mod;
using XMinecraftSuite.Wpf.UserControls;
using XMinecraftSuite.Wpf.ViewModels;

namespace XMinecraftSuite.Wpf.Windows;

/// <summary>
/// MainWindow.xaml 的交互逻辑
/// </summary>
public partial class MainWindow : Window
{
    private readonly MainWindowViewModel ViewModel = new();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = ViewModel;
        ViewModel.SearchCommand.Execute(null);
    }

    #region Events

    private async void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        if (e.VerticalChange <= 0)
            return;
        if (Math.Abs(e.VerticalOffset + e.ViewportHeight - e.ExtentHeight) < 0.001)
        {
            await ViewModel.LoadMore();
        }
    }

    private async void SearchKeyWord_OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            await ViewModel.Search(SearchKeyWord.Text);
        }
    }

    private void SearchModListItem_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left && sender is SearchModListItem item)
        {
            var obj = item.DataContext;
            if (obj is not AbstractModSearchResult clickedItem)
                return;

            ViewModel.SelectedModSlug = clickedItem.Slug;
        }
    }

    /// <summary>
    /// 选择了 ModProvider
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ModProvider_Selected(object sender, MouseButtonEventArgs e)
    {
        if (
            e.ChangedButton == MouseButton.Left
            && sender is Grid { DataContext: KeyValuePair<string, IModProvider> entry }
        )
        {
            var key = entry.Key;
            ViewModel.ProviderKey = key;
        }
    }

    #endregion Events
}
