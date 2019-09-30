using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Blockbuster.Core
{
    public class Client : BaseModel, INotifyPropertyChanged
    {
        private ICollection<Movie> _rentedMovies;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        public ICollection<Movie> RentedMovies 
        { 
            get => _rentedMovies; 
            set
            {
                _rentedMovies = value;
                OnPropertyChanged();
            }
        }

        public Client()
        {
            RentedMovies = new ObservableCollection<Movie>();
        }

        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
