// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics;

namespace XMinecraftSuite;

/// <summary>
/// 异步错误捕获器.
/// </summary>
public static class AsyncErrorHandler
{
    /// <summary>
    /// 异步错误捕获器委托.
    /// </summary>
    /// <param name="exception">发生的错误.</param>
    public delegate void AsyncExceptionHandler(Exception exception);

    /// <summary>
    /// 异步错误发生事件.
    /// </summary>
    public static event AsyncExceptionHandler? AsyncExceptionOccurred;

    /// <summary>
    /// 异步错误捕获器.
    /// </summary>
    /// <param name="exception">捕获到的错误.</param>
    public static void HandleException(Exception exception)
    {
        Debug.WriteLine("Exception occurred: " + exception.Message);
        AsyncExceptionOccurred?.Invoke(exception);
    }
}
