using CommunityToolkit.Diagnostics;
using System.Diagnostics;
using System.Text.Json.Serialization;
using XMinecraftSuite.Core.Models.Abstracts;

namespace XMinecraftSuite.Core.Models.Modrinth
{
    public class ModrinthModDependency : AbstractModDependency
    {
        public override string ProjectId => MProjectId;
        public override bool Required => MDependencyType switch
        {
            "optional" => false,
            "required" => true,
            _ => ThrowHelper.ThrowArgumentException<bool>(nameof(Required)),
        };

        [JsonPropertyName("project_id")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string MProjectId { get; set; } = string.Empty;

        [JsonPropertyName("dependency_type")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string MDependencyType { get; set; } = string.Empty;
    }
}
