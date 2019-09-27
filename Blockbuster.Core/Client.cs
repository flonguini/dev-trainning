using System.Collections.Generic;

namespace Blockbuster.Core
{
    public class Client : BaseModel
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        public ICollection<Movie> RentedMovies { get; set; }

        public Client()
        {
            RentedMovies = new List<Movie>();
        }
    }

}
