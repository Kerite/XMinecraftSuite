// Copyright (c) Keriteal. All rights reserved.

using System.Windows;
using XMinecraftSuite.Gui.ViewModels;

namespace XMinecraftSuite.Wpf.Views;

/// <summary>
/// ModFilesListWindow.xaml 的交互逻辑.
/// </summary>
public partial class ModVersionsListWindow : Window
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModVersionsListWindow"/> class.
    /// </summary>
    /// <param name="factory"><see cref="ModVersionsViewModel"/> 的 Factory.</param>
    /// <param name="slug">ModSlug.</param>
    public ModVersionsListWindow(ModVersionsViewModel.ModVersionsWindowViewModelFactory factory, string slug)
    {
        InitializeComponent();
        this.ViewModel = factory(slug);
        this.DataContext = this.ViewModel;
    }

    /// <summary>
    /// Factory of <see cref="ModVersionsListWindow"/>.
    /// </summary>
    /// <param name="key">ModSlug.</param>
    /// <returns>Mod版本列表.</returns>
    public delegate ModVersionsListWindow ModVersionsListWindowFactory(string key);

    private ModVersionsViewModel ViewModel { get; }
}
