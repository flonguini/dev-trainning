using System;
using System.Windows.Input;

namespace MVVMApp.Commands
{
    public class RelayCommandWithParameter : ICommand
    {
        private readonly Action<object> _action;

        public event EventHandler CanExecuteChanged = (s, e) => { };

        public RelayCommandWithParameter(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
