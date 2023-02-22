// Copyright (c) Keriteal. All rights reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;
using XMinecraftSuite.Core.Services;

namespace XMinecraftSuite.Gui.ViewModels;

/// <summary>
/// Mod版本列表窗口对应的ViewModel.
/// </summary>
public sealed partial class ModVersionsViewModel : ObservableRecipient
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModVersionsViewModel"/> class.
    /// </summary>
    /// <param name="minecraftService">Minecraft 服务.</param>
    /// <param name="slug">Mod的Slug.</param>
    public ModVersionsViewModel(MinecraftService minecraftService, string slug)
    {
        this.Slug = slug;
        this.MinecraftService = minecraftService;
        if (allGameVersions == null)
        {
            _ = SyncMinecraftVersionsAsync();
        }

        _ = SyncModVersionsAsync();
    }

    /// <summary>
    /// 创建 <see cref="ModVersionsViewModel"/> 的委托.
    /// </summary>
    /// <param name="slug">Mod 的 Slug.</param>
    /// <returns>ViewModel.</returns>
    public delegate ModVersionsViewModel ModVersionsWindowViewModelFactory(string slug);

    /// <summary>
    /// Mod Slug.
    /// </summary>
    public string Slug { get; }

    private MinecraftService MinecraftService { get; }

    private bool CanLoadMinecraftVersion() => !this.LoadingMinecraftVersion;

    [RelayCommand]
    private void SelectModVersion(AbstractModVersion version) => this.SelectedModVersionId = version.VersionId;

    [RelayCommand(CanExecute = nameof(CanLoadMinecraftVersion))]
    private async Task SyncMinecraftVersionsAsync()
    {
        this.LoadingMinecraftVersion = true;
        var resultModels = await this.MinecraftService.GetMinecraftVersionsModelAsync(true);
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
