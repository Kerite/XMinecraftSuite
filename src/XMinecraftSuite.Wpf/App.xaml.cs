// Copyright (c) Keriteal. All rights reserved.

using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using XMinecraftSuite.Core;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Services.Config;
using XMinecraftSuite.Wpf.Views;

namespace XMinecraftSuite.Wpf;

/// <summary>
/// App.xaml的交互逻辑.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// 服务提供者.
    /// </summary>
    public static IServiceProvider? ServiceProvider { get; private set; }

    /// <inheritdoc/>
    protected override void OnStartup(StartupEventArgs e)
    {
        var coreSettings = new ConfigServiceBuilder("config.json").RegisterConfig<CoreSettings>()
            .Build();
        ServiceProvider = new ServiceCollection().InjectCoreServices()
            .ConfigureServices(coreSettings)
            .RegisterViewModels()
            .RegisterWindows()
            .BuildServiceProvider();
        DISource.Resolver = ServiceProvider.GetRequiredService;

        ServiceProvider.GetRequiredService<MainWindow>()
            .Show();

        AsyncErrorHandler.AsyncExceptionOccurred += (exception) =>
        {
            MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        };

        base.OnStartup(e);
    }
}
