using Blockbuster.Core;
using Blockbuster.Repository;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Input;

namespace Blockbuster.ViewModels.Register
{
    public class RegisterMovieViewModel : BaseViewModel
    {
        private ObservableCollection<Movie> _movies;
        private string _filterMovie;
        private Movie _movie;
        private Movie _selectedMovie;
        private bool _isRemoveVisible;
        private bool _isProgressBarVisible;

        public bool IsProgressBarVisible
        {
            get => _isProgressBarVisible;
            set
            {
                if (_isProgressBarVisible = value)
                    return;

                _isProgressBarVisible = value;
                OnPropertyChanged();
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
        public Movie Movie
        {
            get => _movie; 
            set
            {
                if (_movie == value)
                    return;

                _movie = value;
                OnPropertyChanged();
            }
        }

        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                if (_selectedMovie == value)
                    return;

                _selectedMovie = value;
                IsRemoveVisible = true;
                OnPropertyChanged();
            }
        }


        public string FilterMovie
        {
            get => _filterMovie;
            set
            {
                if (_filterMovie == value)
                    return;

                _filterMovie = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Movie> Movies
        {
            get => _movies;
            set
            {
                if (_movies == value)
                    return;

                _movies = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public RegisterMovieViewModel()
        {
            Movie = new Movie();
            RegisterCommand = new RelayCommand(RegisterMovie);
            DeleteCommand = new RelayCommand(DeleteMovie);
            IsRemoveVisible = false;
            LoadMoviesAsync();
        }

        private void DeleteMovie()
        {
            if (SelectedMovie == null)
                return;

            using (var context = new BlockbusterContext())
            {
                context.Movies.Attach(SelectedMovie);
                context.Movies.Remove(SelectedMovie);
                context.SaveChanges();
            }

            SelectedMovie = null;
            LoadMoviesAsync();
            IsRemoveVisible = false;
        }

        private void RegisterMovie()
        {
            if (Movie == null)
                return;

            Movie.ReleaseDate = DateTime.Now;

            using (var context = new BlockbusterContext())
            {
                context.Movies.Add(Movie);
                context.SaveChanges();
            }

            Movie = new Movie();

            LoadMoviesAsync();
        }

        private async void LoadMoviesAsync()
        {
            IsProgressBarVisible = true;

            using (var context = new BlockbusterContext())
            {
                Movies = new ObservableCollection<Movie>(await context.Movies.ToListAsync());
            }

            IsProgressBarVisible = false;
        }
    }
}
