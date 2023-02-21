// Copyright (c) Keriteal. All rights reserved.

using XMinecraftSuite.Core.Models;
using XMinecraftSuite.Core.Providers.Mod;

namespace XMinecraftSuite.Core;

/// <summary>
/// 一些通用的消息.
/// </summary>
public static class Messages
{
    /// <summary>
    /// ModProvider被注册时触发.
    /// </summary>
    /// <param name="MetaData">ModProvider 的 <see cref="ModProviderMetaData"/>.</param>
    /// <param name="Provider">被注册的 ModProvider.</param>
    public record ModProviderRegisteredMessage(ModProviderMetaData MetaData, IModProvider Provider);

    /// <summary>
    /// 当配置文件被修改时触发这个消息.
    /// </summary>
    /// <param name="ChangedConfigModel">更改后的配置文件类.</param>
    public record ConfugurationChangedMessage(Type ChangedConfigModel);
}
