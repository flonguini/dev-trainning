using Blockbuster.Enums;
using Blockbuster.Repository;
using System;
using System.Windows.Input;

namespace Blockbuster.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ApplicationPages _mainContent;

        public ApplicationPages MainContent
        {
            get => _mainContent;
            set
            {
                if (_mainContent == value)
                    return;

                _mainContent = value;
                OnPropertyChanged();
            }
        }

        public ICommand MainButtonCommand { get; set; }

        public MainWindowViewModel()
        {
            MainButtonCommand = new RelayParameterizedCommand(ButtonCommand);
        }

        private void ButtonCommand(object page)
        {
            switch ((ApplicationPages)page)
            {
                case ApplicationPages.Register:
                    MainContent = ApplicationPages.Register;
                    break;
                case ApplicationPages.Rent:
                    MainContent = ApplicationPages.Rent;
                    break;
                default:
                    break;
            }
        }
    }
}
