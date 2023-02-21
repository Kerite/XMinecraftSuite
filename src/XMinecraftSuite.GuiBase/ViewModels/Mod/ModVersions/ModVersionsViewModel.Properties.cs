// Copyright (c) Keriteal. All rights reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using XMinecraftSuite.Core;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;
using XMinecraftSuite.Core.Providers;

namespace XMinecraftSuite.Gui.ViewModels;

/// <summary>
/// Mod 版本列表.
/// </summary>
public sealed partial class ModVersionsViewModel
{
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

    /// <summary>
    /// Mod Slug.
    /// </summary>
    public string Slug { get; }

    /// <summary>
    /// 显示在游戏版本列表中的游戏版本.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Critical Code Smell", "S2365:Properties should not make collection or array copies", Justification = "<Pending>.")]
    public List<MinecraftVersionModel> RenderedMinecraftVersions
    {
        get
        {
            var modGameVersions = this.AllModVersions.SelectMany(mod => mod.GameVersions);
            var versions = this.AllGameVersions?.Where(x => x.Type == EnumVersionType.Release || this.IncludeSnapshot)
                .Where(x => modGameVersions?.Contains(x.Id) ?? false);
            return versions?.ToList() ?? new List<MinecraftVersionModel>();
        }
    }

    /// <summary>
    /// 显示在Mod版本列表中的.
    /// </summary>
    public List<AbstractModVersion> RenderedModVersions
    {
        get
        {
            var newList = this.AllModVersions.Where(x => x.GameVersions.Contains(this.SelectedGameVersion))
                .ToList();
            this.SelectedModVersionId = newList.FirstOrDefault()
                ?.VersionId;
            return newList;
        }
    }

    [RelayCommand]
    private void SelectModVersion(AbstractModVersion version)
    {
        this.SelectedModVersionId = version.VersionId;
    }

    [RelayCommand(CanExecute = nameof(CanLoadMinecraftVersion))]
    private async Task SyncMinecraftVersionsAsync()
    {
        this.LoadingMinecraftVersion = true;
        var resultModels = await MCRequestHelper.Instance.GetMinecraftVersionsModelAsync(true);
        this.AllGameVersions = resultModels ?? new List<MinecraftVersionModel>();
        this.LoadingMinecraftVersion = false;
    }

    [RelayCommand]
    private async Task SyncModVersionsAsync()
    {
        this.LoadingModVersion = true;
        this.AllModVersions.Clear();
        var provider = GlobalModProviderProxy.Instance[this.ProviderKey];
        if (provider != null)
        {
            var list = await provider.GetModVersionsAsync(this.Slug);
            this.AllModVersions = list ?? new List<AbstractModVersion>();
        }

        this.LoadingModVersion = false;
    }
}
