using Blockbuster.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Blockbuster.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        public ICommand SubMenuCommand { get; set; }
        public ObservableCollection<SubMenuButton> SubMenuButtons { get; set; }

        public BaseViewModel()
        {
            SubMenuButtons = new ObservableCollection<SubMenuButton>();
        }

        protected virtual void ChangeSubMenuPage(object subMenuName) { }

    }
}
