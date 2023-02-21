// Copyright (c) Keriteal. All rights reserved.

using System.Text.Json;

namespace XMinecraftSuite.Core.JsonConverter;

/// <summary>
/// 转换 Json 属性名为 Snake Case.
/// </summary>
public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    /// <summary>
    /// 单例.
    /// </summary>
    public static SnakeCaseNamingPolicy Instance { get; } = new();

    /// <inheritdoc/>
    public override string ConvertName(string name)
    {
        return name.ToSnakeCase();
    }
}
