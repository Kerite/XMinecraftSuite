﻿using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;

namespace XMinecraftSuite.Gui.ViewModels;

public partial class SearchModListViewModel : ObservableRecipient, IRecipient<GuiMessages.ModProviderSelectedMessage>
{
    public SearchModListViewModel()
    {
        _ = Search();
    }

    public ObservableCollection<AbstractModSearchResult> ModSearchResults { get; set; } = new();

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

    public void Receive(GuiMessages.ModProviderSelectedMessage message)
    {
        ProviderKey = message.Provider;
    }

    private bool CanSearch()
    {
        return !Searching;
    }

    partial void OnSelectedSlugChanged(string value)
    {
        WeakReferenceMessenger.Default.Send(new GuiMessages.ModSelectedMessage(value));
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    [RelayCommand]
    public async Task LoadMoreAsync()
    {
        if (Searching)
        {
            return;
        }

        Searching = true;
        var modProvider = GlobalModProviderProxy.Instance[ProviderKey];
        if (modProvider != null)
        {
            var searchResult = string.IsNullOrEmpty(SearchKeyWord)
                ? await modProvider.SearchModAsync(offset: ModSearchResults.Count)
                : await modProvider.SearchModAsync(SearchKeyWord, offset: ModSearchResults.Count);
            foreach (var mod in searchResult)
            {
                ModSearchResults.Add(mod);
            }
        }

        Searching = false;
    }

    [RelayCommand(CanExecute = nameof(CanSearch))]
    public async Task Search(string? keyWord = null)
    {
        if (this.Searching)
        {
            return;
        }

        this.ModSearchResults.Clear();
        this.Searching = true;
        this.SearchKeyWord = keyWord ?? string.Empty;
        var modProvider = GlobalModProviderProxy.Instance[ProviderKey];
        if (modProvider != null)
        {
            var result = string.IsNullOrEmpty(SearchKeyWord)
                ? await modProvider.SearchModAsync()
                : await modProvider.SearchModAsync(SearchKeyWord);
            foreach (var mod in result)
                ModSearchResults.Add(mod);
            SelectedSlug = ModSearchResults.First()
                .Slug;
        }

        Reset = true;
        Reset = false;
        Searching = false;
    }

    [RelayCommand]
    public void SelectMod(string slug)
    {
        SelectedSlug = slug;
    }
}
