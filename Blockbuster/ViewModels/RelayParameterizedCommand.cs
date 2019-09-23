using System;
using System.Windows.Input;

namespace Blockbuster.ViewModels
{
    public class RelayParameterizedCommand : ICommand
    {
        private readonly Action<object> _action;

        public event EventHandler CanExecuteChanged = (s, e) => { };

        public RelayParameterizedCommand(Action<object> action)
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
