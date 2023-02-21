// Copyright (c) Keriteal. All rights reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;

namespace XMinecraftSuite.Gui.ViewModels;

/// <summary>
/// 主窗口ViewModel.
/// </summary>
public sealed partial class MainWindowViewModel : ObservableObject, IDisposable
{
    private CancellationTokenSource cancellationTokenSource = new();

    [ObservableProperty]
    private string keyWord = string.Empty;

    [ObservableProperty]
    private bool loading;

    [ObservableProperty]
    private AbstractModDetails? modDetails;

    [ObservableProperty]
    private List<AbstractModSearchResult> modSearchResults = new();

    [ObservableProperty]
    private string providerKey = "modrinth";

    [ObservableProperty]
    private bool resetSearchResult;

    [ObservableProperty]
    private bool resetSelectedMod;

    [ObservableProperty]
    private string? selectedModSlug;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="searchModListViewModel"><see cref="SearchModListViewModel"/>.</param>
    /// <param name="panelModProviderSelectorViewModel"><see cref="ModProviderSelectorViewModel"/>.</param>
    /// <param name="modDetailViewModel"><see cref="ModDetailViewModel"/>.</param>
    public MainWindowViewModel(SearchModListViewModel searchModListViewModel, ModProviderSelectorViewModel panelModProviderSelectorViewModel, ModDetailViewModel modDetailViewModel)
    {
        this.SearchModListViewModel = searchModListViewModel;
        this.SearchModListViewModel.IsActive = true;

        this.ModProviderSelectorViewModel = panelModProviderSelectorViewModel;
        this.ModProviderSelectorViewModel.IsActive = true;

        this.ModDetailsViewModel = modDetailViewModel;
        this.ModDetailsViewModel.IsActive = true;
    }

    /// <summary>
    /// Mod 搜索列表.
    /// </summary>
    public SearchModListViewModel SearchModListViewModel { get; init; }

    /// <summary>
    /// ModProviderSelectorViewModel.
    /// </summary>
    public ModProviderSelectorViewModel ModProviderSelectorViewModel { get; init; }

    /// <summary>
    /// Mod 详情.
    /// </summary>
    public ModDetailViewModel ModDetailsViewModel { get; init; }

    /// <inheritdoc/>
    public void Dispose()
    {
        cancellationTokenSource.Cancel();
        this.SearchModListViewModel.IsActive = false;
        this.ModDetailsViewModel.IsActive = false;
        this.ModProviderSelectorViewModel.IsActive = false;
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// 选择 Mod.
    /// </summary>
    /// <param name="slug">Mod 的 Slug.</param>
    [RelayCommand]
    public void SelectMod(string? slug) => this.SelectedModSlug = slug;

    partial void OnSelectedModSlugChanged(string? value)
    {
        cancellationTokenSource.Cancel();
        var newCancellationTokenSource = new CancellationTokenSource();
        Task.Run(async () =>
        {
            var provider = GlobalModProviderProxy.Instance["modrinth"];
            if (value != null && provider != null)
            {
                var data = await provider.GetModDetailAsync(value);
                if (!newCancellationTokenSource.IsCancellationRequested)
                { ModDetails = data; }
            }
        }, newCancellationTokenSource.Token);
        cancellationTokenSource = newCancellationTokenSource;
    }
}
