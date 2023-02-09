using System;
using System.Windows.Input;

namespace XMinecraftSuite.Wpf.Commons.Commands
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> executeAction;
        private readonly Func<T, bool>? canExecuteFunc;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<T> execute, Func<T, bool>? canExecute = null)
        {
            executeAction = execute;
            canExecuteFunc = canExecute;
        }

        bool ICommand.CanExecute(object? parameter)
        {
            return canExecuteFunc == null || canExecuteFunc((T)parameter!);
        }

        void ICommand.Execute(object? parameter)
        {
            executeAction?.Invoke((T)parameter!);
        }
    }
}