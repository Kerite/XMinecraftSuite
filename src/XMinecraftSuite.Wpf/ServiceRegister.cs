// Copyright (c) Keriteal. All rights reserved.

using Microsoft.Extensions.DependencyInjection;
using XMinecraftSuite.Core.Providers;
using XMinecraftSuite.Core.Services.Config;
using XMinecraftSuite.Core.Services.Download;
using XMinecraftSuite.Gui.ViewModels;
using XMinecraftSuite.Wpf.Services.DownloadServices;
using XMinecraftSuite.Wpf.Views;
using XMinecraftSuite.Wpf.Views.UserControls;
using static XMinecraftSuite.Wpf.Views.ModVersionsListWindow;

namespace XMinecraftSuite.Wpf;

internal static class ServiceRegister
{
    internal static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<ModDetailsViewModel>();
        services.AddTransient<ModVersionsWindowViewModel>();
        services.AddTransient<SearchModListViewModel>();
        services.AddTransient<PanelModProviderSelectorViewModel>();
        services.AddTransient(_ =>
        {
            return new ModVersionsWindowViewModel.ModVersionsWindowViewModelFactory(param =>
                new ModVersionsWindowViewModel(param));
        });
        return services;
    }

    internal static IServiceCollection RegisterWindows(this IServiceCollection services)
    {
        services.AddTransient<MainWindow>();
        services.AddTransient<ModVersionsListWindow>();
        services.AddTransient(p => new ModVersionsListWindowFactory(param =>
            new ModVersionsListWindow(
                p.GetRequiredService<ModVersionsWindowViewModel.ModVersionsWindowViewModelFactory>(), param)));
        services.AddTransient<DownloadManagerPanel>();
        return services;
    }

    internal static IServiceCollection ConfigureServices(this IServiceCollection services, ConfigService configuration)
    {
        // Register AppSettings
        services.AddSingleton(configuration);
        services.AddOptions();

        // Register Download Services
        services.AddSingleton<IDownloadService, IDMDownloadManager>();
        services.AddSingleton<GlobalModProviderProxy>();
        return services;
    }
}
