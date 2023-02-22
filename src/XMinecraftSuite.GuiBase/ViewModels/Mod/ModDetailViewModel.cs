// Copyright (c) Keriteal. All rights reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using XMinecraftSuite.Core.Models.Abstracts;
using XMinecraftSuite.Core.Providers;

namespace XMinecraftSuite.Gui.ViewModels;

/// <summary>
/// Mod 详情的 ViewModel.
/// </summary>
public sealed partial class ModDetailViewModel : ObservableRecipient,
    IRecipient<GuiMessages.ModSelectedMessage>,
    IRecipient<GuiMessages.ModProviderSelectedMessage>
{
    [ObservableProperty]
    private AbstractModDetails? modDetail;

    [ObservableProperty]
    private bool reset;

    private string? modProvider = "modrinth";

    /// <inheritdoc/>
    public void Receive(GuiMessages.ModProviderSelectedMessage message) => modProvider = message.Provider;

    /// <inheritdoc/>
    public async void Receive(GuiMessages.ModSelectedMessage message)
    {
        var provider = GlobalModProviderProxy.Instance[modProvider];
        if (provider != null)
        {
            this.ModDetail = await provider.GetModDetailAsync(message.ModSlug);
        }
    }
}
