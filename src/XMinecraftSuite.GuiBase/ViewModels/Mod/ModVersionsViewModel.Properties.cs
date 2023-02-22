// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Models.Enums;

namespace XMinecraftSuite.Gui.ViewModels;

/// <summary>
/// Properties部分.
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
    /// 显示在游戏版本列表中的游戏版本.
    /// </summary>
    [SuppressMessage("Critical Code Smell", "S2365:Properties should not make collection or array copies", Justification = "<Pending>.")]
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

    partial void OnSelectedGameVersionChanged(string? value)
    {
        WeakReferenceMessenger.Default.Send(new GameVersionSelectedMessage(value));
    }

    partial void OnSelectedModVersionIdChanged(string? value)
    {
        WeakReferenceMessenger.Default.Send(new ModVersionSelectedMessage(value));
    }

    partial void OnShowChangeLogChanged(bool value)
    {
        // Not implemented
    }
}
