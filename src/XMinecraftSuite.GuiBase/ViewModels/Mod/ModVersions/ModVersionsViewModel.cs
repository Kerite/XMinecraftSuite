// Copyright (c) Keriteal. All rights reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace XMinecraftSuite.Gui.ViewModels;

/// <summary>
/// Mod版本列表窗口对应的ViewModel.
/// </summary>
public partial class ModVersionsViewModel : ObservableRecipient
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModVersionsViewModel"/> class.
    /// </summary>
    /// <param name="slug">Mod的Slug.</param>
    public ModVersionsViewModel(string slug)
    {
        this.Slug = slug;
        if (allGameVersions == null)
        {
            _ = SyncMinecraftVersionsAsync();
        }

        _ = SyncMinecraftVersionsAsync();
    }

    /// <summary>
    /// 创建 <see cref="ModVersionsViewModel"/> 的委托.
    /// </summary>
    /// <param name="slug">Mod 的 Slug.</param>
    /// <returns>ViewModel.</returns>
    public delegate ModVersionsViewModel ModVersionsWindowViewModelFactory(string slug);

    private bool CanLoadMinecraftVersion() => !this.LoadingMinecraftVersion;

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

    /// <summary>
    /// GameVersion 被选择时的消息.
    /// </summary>
    /// <param name="GameVersion">游戏版本.</param>
    public record GameVersionSelectedMessage(string? GameVersion);

    /// <summary>
    /// ModVersion 被选择的消息.
    /// </summary>
    /// <param name="ModVersionId">Mod 版本.</param>
    public record ModVersionSelectedMessage(string? ModVersionId);
}
