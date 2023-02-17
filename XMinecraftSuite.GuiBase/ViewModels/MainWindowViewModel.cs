using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;

namespace XMinecraftSuite.Gui.ViewModels;

public partial class MainWindowViewModel : ObservableObject, IDisposable
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

    public SearchModListViewModel SearchModListViewModel { get; set; } = new() { IsActive = true };

    public PanelModProviderSelectorViewModel PanelModProviderSelectorViewModel { get; set; } =
        new() { IsActive = true };

    public ModDetailsViewModel ModDetailsViewModel { get; set; } = new() { IsActive = true };

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    [RelayCommand]
    public void SelectMod(string? slug)
    {
        SelectedModSlug = slug;
    }

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
                if (!newCancellationTokenSource.IsCancellationRequested) { ModDetails = data; }
            }
        }, newCancellationTokenSource.Token);
        cancellationTokenSource = newCancellationTokenSource;
    }
}
