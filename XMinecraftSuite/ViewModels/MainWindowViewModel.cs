using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;

namespace XMinecraftSuite.Wpf.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _loading;

    [ObservableProperty]
    private string _keyWord = string.Empty;

    [ObservableProperty]
    private string? _selectedModSlug;

    [ObservableProperty]
    private bool _resetSearchResult;

    [ObservableProperty]
    private string _providerKey = "modrinth";

    [ObservableProperty]
    private List<AbstractModSearchResult> _modSearchResults = new();

    [ObservableProperty]
    private ModDetailsViewModel? selectedModViewModel;

    [ObservableProperty]
    private AbstractModDetails? _modDetails;

    [ObservableProperty]
    private bool _resetSelectedMod;

    [RelayCommand]
    public async Task Search(string? keyWord = null)
    {
        if (Loading)
        {
            return;
        }

        ModSearchResults = new List<AbstractModSearchResult>();

        Loading = true;
        KeyWord = keyWord ?? string.Empty;

        var modProvider = GlobalModProviderProxy.Instance[ProviderKey];
        ModSearchResults = string.IsNullOrEmpty(keyWord)
            ? (await modProvider.Search()).ToList()
            : (await modProvider.Search(KeyWord)).ToList();

        if (ModSearchResults.Count > 0)
        {
            SelectedModSlug = ModSearchResults[0].Slug;
        }
        else
        {
            SelectedModSlug = string.Empty;
        }

        Loading = false;
    }

    [RelayCommand]
    public async Task LoadMore()
    {
        if (Loading)
        {
            return;
        }

        Loading = true;

        var modProvider = GlobalModProviderProxy.Instance[ProviderKey];
        ModSearchResults = ModSearchResults
            .Concat(
                string.IsNullOrEmpty(KeyWord)
                    ? await modProvider.Search()
                    : await modProvider.Search(KeyWord)
            )
            .ToList();

        Loading = false;
    }

    [RelayCommand]
    private void SelectMod(string? slug)
    {
        SelectedModSlug = slug;
    }

    partial void OnSelectedModSlugChanged(string? value)
    {
        _cancellationTokenSource.Cancel();
        var newCancellationTokenSource = new CancellationTokenSource();
        Task.Run(
            () =>
            {
                if (SelectedModSlug == null) {  }
                else
                {
                    var data = GlobalModProviderProxy.Instance["modrinth"]
                        .Details(SelectedModSlug)
                        .Result;
                    if (!newCancellationTokenSource.IsCancellationRequested)
                    {
                        ModDetails = data;
                    }
                }
            },
            newCancellationTokenSource.Token
        );
        _cancellationTokenSource = newCancellationTokenSource;
    }

    private CancellationTokenSource _cancellationTokenSource = new();
}
