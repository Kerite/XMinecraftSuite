using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;

namespace XMinecraftSuite.Wpf.ViewModels;

public partial class MainWindowViewModel : ObservableObject, IDisposable
{
    private CancellationTokenSource _cancellationTokenSource = new();

    public SearchModListViewModel SearchModListViewModel { get; set; } = new()
    {
        IsActive = true
    };

    public PanelModProviderSelectorViewModel PanelModProviderSelectorViewModel { get; set; } = new()
    {
        IsActive = true
    };

    public ModDetailsViewModel ModDetailsViewModel { get; set; } = new()
    {
        IsActive = true
    };

    #region 命令 RelayCommands
    [RelayCommand]
    public void SelectMod(string? slug)
    {
        SelectedModSlug = slug;
    }
    #endregion

    #region 方法 Methods
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    partial void OnSelectedModSlugChanged(string? value)
    {
        _cancellationTokenSource.Cancel();
        var newCancellationTokenSource = new CancellationTokenSource();
        Task.Run(async () =>
        {
            var provider = GlobalModProviderProxy.Instance["modrinth"];
            if (value != null && provider != null)
            {
                var data = await provider.GetModDetailAsync(value);
                if (!newCancellationTokenSource.IsCancellationRequested) ModDetails = data;
            }
        }, newCancellationTokenSource.Token);
        _cancellationTokenSource = newCancellationTokenSource;
    }
    #endregion

    #region ObservableProperties
    [ObservableProperty] private string _keyWord = string.Empty;

    [ObservableProperty] private bool _loading;

    [ObservableProperty] private AbstractModDetails? _modDetails;

    [ObservableProperty] private List<AbstractModSearchResult> _modSearchResults = new();

    [ObservableProperty] private string _providerKey = "modrinth";

    [ObservableProperty] private bool _resetSearchResult;

    [ObservableProperty] private bool _resetSelectedMod;

    [ObservableProperty] private string? _selectedModSlug;
    #endregion
}
