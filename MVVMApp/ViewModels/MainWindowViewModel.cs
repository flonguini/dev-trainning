namespace MVVMApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Private Members

        private string _title = "Binding Works";

        #endregion

        #region Public Properties

        public string Title
        {
            get => _title;
            set
            {
                if (_title == value)
                    return;

                _title = value;
                OnPropertyChanged();
            }
        }

        #endregion

    }
}
