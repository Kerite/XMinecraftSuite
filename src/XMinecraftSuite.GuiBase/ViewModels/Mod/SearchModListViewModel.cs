// Copyright (c) Keriteal. All rights reserved.

using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;

namespace XMinecraftSuite.Gui.ViewModels;

/// <summary>
/// 搜索模组的结果.
/// </summary>
public sealed partial class SearchModListViewModel : ObservableRecipient, IRecipient<GuiMessages.ModProviderSelectedMessage>
{
    [ObservableProperty]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string providerKey = "modrinth";

    [ObservableProperty]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private bool reset;

    [ObservableProperty]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    [NotifyCanExecuteChangedFor(nameof(SearchCommand))]
    private bool searching;

    [ObservableProperty]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string searchKeyWord = string.Empty;

    [ObservableProperty]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string selectedSlug = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="SearchModListViewModel"/> class.
    /// </summary>
    public SearchModListViewModel() => _ = SearchAsync();

    /// <summary>
    /// Mod 搜索结果.
    /// </summary>
    public ObservableCollection<AbstractModSearchResult> ModSearchResults { get; set; } = new();

    /// <inheritdoc/>
    public void Receive(GuiMessages.ModProviderSelectedMessage message) => this.ProviderKey = message.Provider;

    /// <summary>
    /// 加载更多.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    [RelayCommand]
    public async Task LoadMoreAsync()
    {
        if (this.Searching)
        {
            return;
        }

        this.Searching = true;
        var modProvider = GlobalModProviderProxy.Instance[this.ProviderKey];
        if (modProvider != null)
        {
            var searchResult = string.IsNullOrEmpty(this.SearchKeyWord)
                ? await modProvider.SearchModAsync(offset: this.ModSearchResults.Count)
                : await modProvider.SearchModAsync(this.SearchKeyWord, offset: this.ModSearchResults.Count);
            foreach (var mod in searchResult)
            {
                this.ModSearchResults.Add(mod);
            }
        }

        this.Searching = false;
    }

    /// <summary>
    /// 搜索 Mod.
    /// </summary>
    /// <param name="keyWord">关键字.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    [RelayCommand(CanExecute = nameof(CanSearch))]
    public async Task SearchAsync(string? keyWord = null)
    {
        if (this.Searching)
        {
            return;
        }

        this.ModSearchResults.Clear();
        this.Searching = true;
        this.SearchKeyWord = keyWord ?? string.Empty;
        var modProvider = GlobalModProviderProxy.Instance[this.ProviderKey];
        if (modProvider != null)
        {
            var result = string.IsNullOrEmpty(this.SearchKeyWord)
                ? await modProvider.SearchModAsync()
                : await modProvider.SearchModAsync(this.SearchKeyWord);
            foreach (var mod in result)
            {
                this.ModSearchResults.Add(mod);
            }

            this.SelectedSlug = this.ModSearchResults.First()
                .Slug;
        }

        this.Reset = true;
        this.Reset = false;
        this.Searching = false;
    }

    /// <summary>
    /// 选择 Mod.
    /// </summary>
    /// <param name="slug">被选择的Slug.</param>
    [RelayCommand]
    public void SelectMod(string slug) => this.SelectedSlug = slug;

    private bool CanSearch() => !this.Searching;

    partial void OnSelectedSlugChanged(string value)
    {
        WeakReferenceMessenger.Default.Send(new GuiMessages.ModSelectedMessage(value));
    }
}
