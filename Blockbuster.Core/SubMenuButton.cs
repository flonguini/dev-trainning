using System.Windows.Input;

namespace Blockbuster.Core
{
    public class SubMenuButton
    {
        public string Content { get; set; }

        public ICommand Command { get; set; }

        public object Parameter { get; set; }

        public SubMenuButton(string content, ICommand command, object parameter)
        {
            Content = content;
            Command = command;
            Parameter = parameter;
        }
    }
}
