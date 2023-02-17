using System.Diagnostics;

namespace XMinecraftSuite.Wpf;

public static class AsyncErrorHandler
{
    public static void HandleException(Exception exception)
    {
        Debug.WriteLine("Exception occurred: " + exception.Message);
    }
}
