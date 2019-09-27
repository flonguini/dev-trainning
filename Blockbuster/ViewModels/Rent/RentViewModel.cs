using Blockbuster.Core;
using Blockbuster.Enums;

namespace Blockbuster.ViewModels.Rent
{
    public class RentViewModel : BaseViewModel
    {
        private RentPages _rentContent;

        public RentPages RentContent
        {
            get => _rentContent;
            set
            {
                if (_rentContent == value)
                    return;

                _rentContent = value;
                OnPropertyChanged();
            }
        }

        public RentViewModel()
        {
            SubMenuCommand = new RelayParameterizedCommand(ChangeSubMenuPage);

            SubMenuButtons.Add(new SubMenuButton("Alugar Filmes", SubMenuCommand, RentPages.Rent));
            SubMenuButtons.Add(new SubMenuButton("Devolução de Filmes", SubMenuCommand, RentPages.Return));
        }

        protected override void ChangeSubMenuPage(object menuName)
        {
            switch ((RentPages)menuName)
            {
                case RentPages.Rent:
                    RentContent = RentPages.Rent;
                    break;
                case RentPages.Return:
                    RentContent = RentPages.Return;
                    break;
                default:
                    break;
            }
        }
    }
}
