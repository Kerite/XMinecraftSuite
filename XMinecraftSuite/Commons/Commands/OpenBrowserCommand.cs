using System;
using System.Diagnostics;
using System.Windows.Input;

namespace XMinecraftSuite.Wpf.Commons.Commands
{
    public class OpenBrowserCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Func<string> _urlPredicate;

        public OpenBrowserCommand(Predicate<object> canExecute, Func<string> urlPredicate)
        {
            _canExecute = canExecute;
            _urlPredicate = urlPredicate;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            var url = _urlPredicate();
            Process.Start(url);
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}