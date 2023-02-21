// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics;
using System.Text.Json.Serialization;
using CommunityToolkit.Diagnostics;
using XMinecraftSuite.Core.Models.Abstracts;

namespace XMinecraftSuite.Core.Models.Modrinth;

/// <summary>
/// Modrinth Mod 的依赖项.
/// </summary>
public class ModrinthModDependency : AbstractModDependency
{
    /// <inheritdoc/>
    public override string ProjectId => this.MProjectId;

    /// <inheritdoc/>
    public override bool Required => this.MDependencyType switch
    {
        "optional" => false,
        "required" => true,
        _ => ThrowHelper.ThrowArgumentException<bool>(nameof(this.Required)),
    };

    /// <summary>
    /// Json value of <see cref="ProjectId"/>.
    /// </summary>
    [JsonPropertyName("project_id")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MProjectId { get; set; } = string.Empty;

    /// <summary>
    /// Json value of <see cref="Required"/>.
    /// </summary>
    [JsonPropertyName("dependency_type")]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public string MDependencyType { get; set; } = string.Empty;
}
