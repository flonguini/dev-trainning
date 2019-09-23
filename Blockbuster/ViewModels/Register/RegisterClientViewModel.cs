using Blockbuster.Core;
using Blockbuster.Repository;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Blockbuster.ViewModels.Register
{
    public class RegisterClientViewModel : BindableBase
    {
        private Client _client;
        private string _filterClient;
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
            LoadClients();
        }

        private void Delete()
        {
            using (var context = new BlockbusterContext())
            {
                context.Clients.Attach(Client);
                context.Clients.Remove(Client);
                context.SaveChanges();
            }

            LoadClients();
        }

        private void Register()
        {
            using (var context = new BlockbusterContext())
            {
                context.Clients.Add(Client);
                context.SaveChanges();
            }

            LoadClients();
            Client = new Client();
        }

        private void LoadClients()
        {
            using (var context = new BlockbusterContext())
            {
                Clients = new ObservableCollection<Client>(context.Clients.ToList());
            }
        }

        private void Filter()
        {
            FilteredClients = new ObservableCollection<Client>(Clients.Where(c => c.Name.Contains(FilterClient)));
        }
    }
}
