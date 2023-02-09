using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;
using XMinecraftSuite.Core.Providers.Mod;
using XMinecraftSuite.Wpf.UserControls;
using XMinecraftSuite.Wpf.ViewModels;

namespace XMinecraftSuite.Wpf.Windows;

/// <summary>
/// MainWindow.xaml 的交互逻辑
/// </summary>
public partial class MainWindow : Window
{
    public readonly MainWindowViewModel ViewModel = new();
    private CancellationTokenSource _cancellationTokenSource = new();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = ViewModel;
        ViewModel.Search();
        ViewModel.ModSelected += new MainWindowViewModel.ModSelectedEventHandler(OnModSelected);
    }

    private void button_Click(object sender, RoutedEventArgs e)
    {
        ViewModel.Search(SearchKeyWord.Text);
    }

    #region 事件

    /// <summary>
    /// 列表被滚动
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ScrollViewer_ScrollChanged(object sender, System.Windows.Controls.ScrollChangedEventArgs e)
    {
        if (!(e.VerticalChange > 0)) return;
        if (Math.Abs(e.VerticalOffset + e.ViewportHeight - e.ExtentHeight) < 0.001)
        {
            ViewModel.LoadMore();
        }
    }

    /// <summary>
    /// 回车开始搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SearchKeyWord_OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            ViewModel.Search(SearchKeyWord.Text);
        }
    }

    /// <summary>
    /// 选择了搜索结果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SearchModListItem_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton != MouseButton.Left || sender is not SearchModListItem searchModListItem) return;

        var obj = searchModListItem.DataContext;
        if (obj is not AbstractModSearchResult clickedItem) return;

        ViewModel.SelectedModSlug = clickedItem.Slug;
    }

    #endregion 事件

    private void ModProvider_Selected(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton != MouseButton.Left || sender is not Grid
            {
                DataContext: KeyValuePair<string, IModProvider> entry
            }) return;
        var key = entry.Key;
        ViewModel.ProviderKey = key;
    }

    private void OnModSelected(string? modSlug)
    {
        if (modSlug == null)
        {
            ViewModel.SelectedModViewModel.ModDetails = null;
            return;
        }

        // 取消之前的任务
        _cancellationTokenSource.Cancel();
        var newCancellationTokenSource = new CancellationTokenSource();
        Task.Run(() =>
        {
            var data = GlobalModProviderProxy.Instance["modrinth"].Details(modSlug)
                .Result;
            if (!newCancellationTokenSource.IsCancellationRequested)
            {
                ViewModel.SelectedModViewModel.ModDetails = data;
            }
        }, newCancellationTokenSource.Token);
        _cancellationTokenSource = newCancellationTokenSource;
    }
}