// Copyright (c) Keriteal. All rights reserved.

using System.Collections.ObjectModel;
using XMinecraftSuite.Core.Models.Configs;
using XMinecraftSuite.Core.Services.Config;

namespace XMinecraftSuite.Core.Services;

/// <summary>
/// Java 管理.
/// </summary>
public class JavaService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="JavaService"/> class.
    /// </summary>
    /// <param name="configService">配置服务.</param>
    public JavaService(ConfigService configService)
    {
        this.ConfigService = configService.GetConfig<CoreSettings>();
    }

    /// <summary>
    /// Java Runtime 列表.
    /// </summary>
    public ObservableCollection<string> JavaRuntimeList { get; } = new();

    private CoreSettings ConfigService { get; }
}
