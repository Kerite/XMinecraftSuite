using System.Diagnostics;

namespace XMinecraftSuite.Core.Models.Abstracts;

[DebuggerDisplay("ProjectId = {ProjectId}")]
public abstract class AbstractModDependency
{
    public abstract string ProjectId { get; }
    public abstract bool Required { get; }
}
