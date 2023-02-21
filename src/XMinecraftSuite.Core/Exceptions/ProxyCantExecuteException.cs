// Copyright (c) Keriteal. All rights reserved.

using System.Runtime.Serialization;

namespace XMinecraftSuite.Core.Exceptions;

/// <summary>
/// 无法执行.
/// </summary>
[Serializable]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3925:\"ISerializable\" should be implemented correctly", Justification = "<Pending>.")]
public class ProxyCantExecuteException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProxyCantExecuteException"/> class.
    /// </summary>
    public ProxyCantExecuteException()
        : base("This function can't called in a proxy")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProxyCantExecuteException"/> class.
    /// </summary>
    /// <param name="message">Exception Message.</param>
    public ProxyCantExecuteException(string? message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProxyCantExecuteException"/> class.
    /// </summary>
    /// <param name="message">Exception Message.</param>
    /// <param name="innerException">Inner Exception.</param>
    public ProxyCantExecuteException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProxyCantExecuteException"/> class.
    /// </summary>
    /// <param name="serializationInfo">Serialization Info.</param>
    /// <param name="streamingContext">Streaming Context.</param>
    protected ProxyCantExecuteException(SerializationInfo serializationInfo, StreamingContext streamingContext)
    {
        // Not Implemented
    }
}
