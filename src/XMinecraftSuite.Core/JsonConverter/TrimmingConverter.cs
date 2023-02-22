// Copyright (c) Keriteal. All rights reserved.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace XMinecraftSuite.Core.JsonConverter;

/// <summary>
/// 删除输出和输入的字符串的首尾空格.
/// </summary>
public class TrimmingConverter : JsonConverter<string>
{
    /// <inheritdoc/>
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString()
            ?.Trim();
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) => writer.WriteStringValue(value?.Trim());
}
