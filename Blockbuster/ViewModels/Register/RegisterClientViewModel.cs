using Blockbuster.Core;
using Blockbuster.Repository;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;

namespace Blockbuster.ViewModels.Register
{
    public class RegisterClientViewModel : BindableBase
    {
        private Client _client;
        private Client _selectedClient;
        private string _filterClient;
        private bool _isRemoveVisible;
        private bool _isProgressBarVisible;
        private ObservableCollection<Client> _clients;
        private ObservableCollection<Client> _filteredClients;
        
        public ObservableCollection<Client> FilteredClients
        {
            get => _filteredClients;
            set
            {
                if (_filteredClients == value)
                    return;

                _filteredClients = value;
                OnPropertyChanged();
            }
        }

        public bool IsProgressBarVisible
        {
            get => _isProgressBarVisible;
            set
            {
                if (_isProgressBarVisible == value)
                    return;

                _isProgressBarVisible = value;
                OnPropertyChanged();
            }
        }

        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                if (_selectedClient == value)
                    return;

                _selectedClient = value;
                OnPropertyChanged();
                IsRemoveVisible = true;
            }
        }      

        public bool IsRemoveVisible
        {
            get => _isRemoveVisible; 
            set
            {
                if (_isRemoveVisible == value)
                    return;

                _isRemoveVisible = value;
                OnPropertyChanged();
            }
        }

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
                Filter();
            }
        }

        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set
            {
                if (_clients == value)
                    return;

                _clients = value;
                OnPropertyChanged();
                FilteredClients = new ObservableCollection<Client>(_clients);
            }
        }

        public ICommand RegisterCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public RegisterClientViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
            DeleteCommand = new RelayCommand(Delete);
            Client = new Client();
            IsRemoveVisible = false;
            //Boa prática??
            LoadClientsAsync();
        }

        private void Delete()
        {
            if (SelectedClient == null)
                return;

            using (var context = new BlockbusterContext())
            {
                context.Clients.Attach(SelectedClient);
                context.Clients.Remove(SelectedClient);
                context.SaveChanges();
            }

            SelectedClient = null;
            LoadClientsAsync();
            IsRemoveVisible = false;
        }

        private void Register()
        {
            using (var context = new BlockbusterContext())
            {
                context.Clients.Add(Client);
                context.SaveChanges();
            }

            LoadClientsAsync();
            Client = new Client();
        }

        private async void LoadClientsAsync()
        {
            IsProgressBarVisible = true;

            using (var context = new BlockbusterContext())
            {
                Clients = new ObservableCollection<Client>(await context.Clients.ToListAsync());
            }

            IsProgressBarVisible = false;
        }

        private void Filter()
        {
            FilteredClients = new ObservableCollection<Client>(Clients.Where(c => c.Name.Contains(FilterClient)));
        }
    }
}
