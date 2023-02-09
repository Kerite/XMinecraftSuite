namespace XMinecraftSuite.Core.Excceptions;

public class ProxyCantExecuteException : Exception
{
    public ProxyCantExecuteException() : base("This function can't called in a proxy")
    {
    }

    public ProxyCantExecuteException(string? message) : base(message)
    {
    }

    public ProxyCantExecuteException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}