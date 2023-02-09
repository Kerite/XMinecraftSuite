using XMinecraftSuite.Core.Excceptions;

namespace XMinecraftSuite.Core.Commons;

public static class ExceptionHelper
{
    public static ProxyCantExecuteException ProxyCantExecuteException => new ProxyCantExecuteException();
}