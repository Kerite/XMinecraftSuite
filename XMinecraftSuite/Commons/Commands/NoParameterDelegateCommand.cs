using System;
using System.Windows.Input;

namespace XMinecraftSuite.Wpf.Commons.Commands
{
    public class NoParameterDelegateCommand : ICommand
    {
        private readonly Action executeAction;
        private readonly Func<bool>? canExecuteFunc;

        public NoParameterDelegateCommand(Action executeAction) : this(executeAction, null)
        {
        }

        public NoParameterDelegateCommand(Action executeAction, Func<bool>? canExecuteFunc)
        {
            this.executeAction = executeAction;
            this.canExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object? _)
        {
            return canExecuteFunc?.Invoke() ?? false;
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        public void Execute(object? _)
        {
            executeAction.Invoke();
        }

        public event EventHandler? CanExecuteChanged;
    }
}