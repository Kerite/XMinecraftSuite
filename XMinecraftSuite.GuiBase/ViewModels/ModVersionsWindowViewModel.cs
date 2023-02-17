﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using XMinecraftSuite.Core;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;
using XMinecraftSuite.Core.Providers;

namespace XMinecraftSuite.Gui.ViewModels;

public partial class ModVersionsWindowViewModel : ObservableRecipient
{
    public delegate ModVersionsWindowViewModel ModVersionsWindowViewModelFactory(string slug);

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(RenderedMinecraftVersions))]
    private static List<MinecraftVersionModel>? allGameVersions;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(RenderedMinecraftVersions))]
    [NotifyPropertyChangedFor(nameof(RenderedModVersions))]
    private List<AbstractModVersion> allModVersions = new();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(RenderedMinecraftVersions))]
    private bool includeSnapshot = false;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SyncMinecraftVersionsCommand))]
    private bool loadingMinecraftVersion = false;

    [ObservableProperty]
    private bool loadingModVersion = false;

    [ObservableProperty]
    private string providerKey = "modrinth";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(RenderedModVersions))]
    private string? selectedGameVersion;

    [ObservableProperty]
    private string? selectedModVersionId;

    [ObservableProperty]
    private bool showChangeLog = true;

    public ModVersionsWindowViewModel(string slug)
    {
        Slug = slug;
        if (allGameVersions == null) { _ = SyncMinecraftVersions(); }

        _ = SyncModVersions();
    }

    public string Slug { get; }

    public List<MinecraftVersionModel> RenderedMinecraftVersions
    {
        get
        {
            var modGameVersions = AllModVersions.SelectMany(mod => mod.GameVersions);
            var versions = AllGameVersions?.Where(x => x.Type == EnumVersionType.Release || IncludeSnapshot)
                .Where(x => modGameVersions?.Contains(x.Id) ?? false);
            return versions?.ToList() ?? new List<MinecraftVersionModel>();
        }
    }

    public List<AbstractModVersion> RenderedModVersions
    {
        get
        {
            var newList = AllModVersions.Where(x => x.GameVersions.Contains(SelectedGameVersion))
                .ToList();
            SelectedModVersionId = newList.FirstOrDefault()
                ?.VersionId;
            return newList;
        }
    }

    private bool CanLoadMinecraftVersion()
    {
        return !LoadingMinecraftVersion;
    }

    partial void OnSelectedGameVersionChanged(string? value)
    {
        WeakReferenceMessenger.Default.Send(new GameVersionSelectedMessage(value));
    }

    partial void OnSelectedModVersionIdChanged(string? value)
    {
        WeakReferenceMessenger.Default.Send(new ModVersionSelectedMessage(value));
    }

    partial void OnShowChangeLogChanged(bool value) { }

    [RelayCommand]
    private void SelectModVersion(AbstractModVersion version)
    {
        SelectedModVersionId = version.VersionId;
    }

    [RelayCommand(CanExecute = nameof(CanLoadMinecraftVersion))]
    private async Task SyncMinecraftVersions()
    {
        LoadingMinecraftVersion = true;
        var resultModels = await MCRequestHelper.Instance.GetMinecraftVersionsModelAsync(true);
        AllGameVersions = resultModels ?? new List<MinecraftVersionModel>();
        LoadingMinecraftVersion = false;
    }

    [RelayCommand]
    private async Task SyncModVersions()
    {
        LoadingModVersion = true;
        AllModVersions.Clear();
        var provider = GlobalModProviderProxy.Instance[ProviderKey];
        if (provider != null)
        {
            var list = await provider.GetModVersionsAsync(Slug);
            AllModVersions = list ?? new List<AbstractModVersion>();
        }

        LoadingModVersion = false;
    }

    public record GameVersionSelectedMessage(string? GameVersion);

    public record ModVersionSelectedMessage(string? ModVersionId);
}
