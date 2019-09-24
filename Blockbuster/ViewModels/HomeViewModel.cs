using Blockbuster.Repository;
using System;
using System.Linq;

namespace Blockbuster.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private int _moviesCount;

        public int MoviesCount
        {
            get { return _moviesCount; }
            set
            {
                if (_moviesCount == value)
                    return;

                _moviesCount = value;
                OnPropertyChanged();
            }
        }

        private int _clientsCount;

        public int ClientsCount
        {
            get => _clientsCount;
            set
            {
                if (_clientsCount == value)
                    return;

                _clientsCount = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            GetClients();
            GetMovies();
        }

        private void GetMovies()
        {
            using (var context = new BlockbusterContext())
            {
                MoviesCount = context.Movies.ToList().Count;
            }
        }

        private void GetClients()
        {
            using (var context = new BlockbusterContext())
            {
                ClientsCount = context.Clients.ToList().Count;
            }
        }
    }
}
