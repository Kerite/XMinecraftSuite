// Copyright (c) Keriteal. All rights reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace XMinecraftSuite.Gui.ViewModels;

/// <summary>
/// ModProvider选择器.
/// </summary>
public sealed partial class ModProviderSelectorViewModel : ObservableRecipient
{
    [ObservableProperty]
    private string selectedProvider = "modrinth";

    partial void OnSelectedProviderChanged(string value)
    {
        WeakReferenceMessenger.Default.Send(value);
    }
}
