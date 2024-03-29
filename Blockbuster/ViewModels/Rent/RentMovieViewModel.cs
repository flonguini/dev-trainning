﻿using Blockbuster.Core;
using Blockbuster.Repository;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;

namespace Blockbuster.ViewModels.Rent
{
    public class RentMovieViewModel : BaseViewModel
    {
        private string _clientCpf;
        private Client _client;
        private ObservableCollection<Movie> _movies;
        private Movie _selectedMovie;

        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                if (_selectedMovie == value)
                    return;

                _selectedMovie = value;
                
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

        public string ClientCpf 
        { 
            get => _clientCpf;
            set
            {
                if (_clientCpf == value)
                    return;

                _clientCpf = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Client));
            } 
        }

        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set 
            {
                if (_movies == value)
                    return;

                _movies = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchClientCommand { get; set; }
        public ICommand AddMovieCommand { get; set; }
        public ICommand RemoveMovieCommand { get; set; }

        public RentMovieViewModel()
        {
            SearchClientCommand = new RelayCommand(SearchClient);
            AddMovieCommand = new RelayCommand(AddMovie);
            RemoveMovieCommand = new RelayCommand(RemoveMovie);
            LoadMovies();
        }

        private async void LoadMovies()
        {
            using (var context = new BlockbusterContext())
            {
                Movies = new ObservableCollection<Movie>(await context.Movies.ToListAsync());
            }
        }

        private void RemoveMovie()
        {
            throw new NotImplementedException();
        }

        private void AddMovie()
        {
            if (SelectedMovie != null && Client != null)
            {
                SelectedMovie.QuantityInStock += -1;

                UpdateRentedMovie(SelectedMovie);
            }

            LoadMovies();
        }

        private async void UpdateRentedMovie(Movie selectedMovie)
        {
            using (var context = new BlockbusterContext())
            {
                var movieToUpdate = await context.Movies.FirstOrDefaultAsync(m => m.Id == SelectedMovie.Id);

                if (movieToUpdate == null)
                    return;

                movieToUpdate.QuantityInStock = selectedMovie.QuantityInStock;

                //TODO: Update DB
                Client.RentedMovies.Add(selectedMovie);

                await context.SaveChangesAsync();
            }
        }

        private async void SearchClient()
        {
            using (var context = new BlockbusterContext())
            {
                Client = await context.Clients.FirstOrDefaultAsync(client => client.CPF == _clientCpf);
            }
        }
  
    }
}
