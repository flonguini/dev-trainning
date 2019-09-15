using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        protected Dictionary<string, List<string>> _errorsList;
        public bool HasErrors => _errorsList.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public BaseViewModel()
        {
            _errorsList = new Dictionary<string, List<string>>();
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_errorsList.ContainsKey(propertyName))
                return null;

            return _errorsList[propertyName];
        }

        protected void AddError(string propertyName, string error)
        {
            if (!_errorsList.ContainsKey(propertyName))
                _errorsList[propertyName] = new List<string>();

            if (!_errorsList[propertyName].Contains(error))
                _errorsList[propertyName].Add(error);

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        
    }
}
