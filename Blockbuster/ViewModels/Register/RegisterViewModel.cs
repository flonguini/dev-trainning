using Blockbuster.Core;
using Blockbuster.Enums;

namespace Blockbuster.ViewModels.Register
{
    public class RegisterViewModel : BaseViewModel
    {
        private RegisterPages _registerContent;

        public RegisterPages RegisterContent
        {
            get => _registerContent; 
            set
            {
                if (_registerContent == value)
                    return;

                _registerContent = value;
                OnPropertyChanged();
            }
        }

        public RegisterViewModel()
        {
            SubMenuCommand = new RelayParameterizedCommand(ChangeSubMenuPage);

            SubMenuButtons.Add(new SubMenuButton("Novo Cliente", SubMenuCommand, RegisterPages.Client));
            SubMenuButtons.Add(new SubMenuButton("Novo Filme", SubMenuCommand, RegisterPages.Movie));

        }

        protected override void ChangeSubMenuPage(object menuName)
        {
            switch ((RegisterPages)menuName)
            {
                case RegisterPages.Client:
                    // Open the register client page
                    RegisterContent = RegisterPages.Client;
                    break;
                case RegisterPages.Movie:
                    // Open the register supplier page
                    RegisterContent = RegisterPages.Movie;
                    break;
                default:
                    break;
            }
        }
    }
}
