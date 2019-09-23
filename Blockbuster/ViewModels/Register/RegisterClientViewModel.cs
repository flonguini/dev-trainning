using Blockbuster.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Blockbuster.ViewModels.Register
{
    public class RegisterClientViewModel : BindableBase
    {
        private Client _client;
        private string _filterClient;

        public Client Client
        {
            get => _client;
            set
            {
                if (_client == value)
                    return;

                _client = value;
                OnPropertyChanged();
            }
        }
        public string FilterClient
        {
            get => _filterClient;
            set
            {
                if (_filterClient == value)
                    return;

                _filterClient = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Client> _clients;

        public ObservableCollection<Client> Clients
        {
            get =>  _clients;
            set
            {
                if (_clients == value)
                    return;

                _clients = value;
                OnPropertyChanged();
            }
        }


        public ICommand RegisterCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public RegisterClientViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
            DeleteCommand = new RelayCommand(Delete);
            Client = new Client();

            Clients = new ObservableCollection<Client>
            {
                new Client
                {
                 Cellphone = "3565-5495",
                 City = "São Caetano do Sul",
                 CPF = "395.891.568-00",
                 Email = "Flonguini@dsf.sdf",
                 Name = "Fernando",
                 Neighborhood = "nova Gerty",
                 Street = "Rua Gurupi",
                 Zipcode = "09572-460"
                }
            };
        }

        private void Delete()
        {
        }

        private void Register()
        {
        }
    }
}
