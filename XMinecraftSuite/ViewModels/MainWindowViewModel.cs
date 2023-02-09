using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XMinecraftSuite.Core.Commons;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;
using XMinecraftSuite.Wpf.Commons;

namespace XMinecraftSuite.Wpf.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private bool _loading;
    private string _keyWord = string.Empty;
    private string? _selectedModSlug;
    private bool _resetSearchResult;
    private string _providerKey = "modrinth";

    public delegate void ModSelectedEventHandler(string? selectedSlug);

    public event ModSelectedEventHandler? ModSelected;

    public List<AbstractModSearchResult> ModSearchResults { get; private set; } = new();
    public ModDetailsViewModel SelectedModViewModel { get; } = new();

    public string ProviderKey
    {
        get => _providerKey;
        set
        {
            _providerKey = value;
            RaisePropertyChangedEvent(nameof(ProviderKey));
        }
    }

    public bool ResetSearchResult
    {
        get => _resetSearchResult;
        set
        {
            _resetSearchResult = value;
            RaisePropertyChangedEvent(nameof(ResetSearchResult));
        }
    }

    public bool Searching
    {
        get => _loading;
        private set
        {
            _loading = value;
            RaisePropertyChangedEvent(nameof(Searching));
        }
    }

    public string? SelectedModSlug
    {
        get => _selectedModSlug;
        set
        {
            _selectedModSlug = value;
            RaisePropertyChangedEvent(nameof(SelectedModSlug));
            ModSelected?.Invoke(value);
        }
    }

    public async void Search(string? keyWord = null)
    {
        if (Searching)
        {
            return;
        }

        ModSearchResults = new List<AbstractModSearchResult>();
        RaisePropertyChangedEvent(nameof(ModSearchResults));

        Searching = true;
        _keyWord = keyWord ?? string.Empty;

        var modProvider = GlobalModProviderProxy.Instance[_providerKey];
        ModSearchResults = string.IsNullOrEmpty(keyWord)
            ? (await modProvider.Search()).ToList()
            : (await modProvider.Search(_keyWord)).ToList();
        RaisePropertyChangedEvent(nameof(ModSearchResults));

        SelectedModSlug = ModSearchResults[0].Slug;

        Searching = false;
    }

    public async void LoadMore()
    {
        if (Searching)
        {
            return;
        }

        Searching = true;

        var modProvider = GlobalModProviderProxy.Instance[ProviderKey];
        ModSearchResults = ModSearchResults.Concat(string.IsNullOrEmpty(_keyWord)
                ? await modProvider.Search()
                : await modProvider.Search(_keyWord))
            .ToList();

        RaisePropertyChangedEvent(nameof(ModSearchResults));
        Searching = false;
    }
}