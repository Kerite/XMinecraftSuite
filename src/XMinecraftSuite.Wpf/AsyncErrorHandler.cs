// Copyright (c) Keriteal. All rights reserved.

using System.Diagnostics;
using System.Windows;

namespace XMinecraftSuite.Wpf;

/// <summary>
/// 异步错误捕获器.
/// </summary>
public static class AsyncErrorHandler
{
    /// <summary>
    /// 异步错误捕获器.
    /// </summary>
    /// <param name="exception">捕获到的错误.</param>
    public static void HandleException(Exception exception)
    {
        Debug.WriteLine("Exception occurred: " + exception.Message);
        MessageBox.Show(exception.Message, "执行后台任务时发生错误");
    }
}
