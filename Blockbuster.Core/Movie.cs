using System;

namespace Blockbuster.Core
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int Rate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RuntimeInMinutes { get; set; }
        public string Banner { get; set; }
    }
}
