// Copyright (c) Keriteal. All rights reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using XMinecraftSuite.Core.Models.Abstracts;

namespace XMinecraftSuite.Gui.ViewModels;

/// <summary>
/// Mod 详情组件的 ViewModel.
/// </summary>
public sealed partial class ModDetailViewModel
{
    [ObservableProperty]
    private AbstractModDetails? modDetail;

    [ObservableProperty]
    private bool reset;
}
