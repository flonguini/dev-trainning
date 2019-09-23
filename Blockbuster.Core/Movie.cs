using System;

namespace Blockbuster.Core
{
    public class Movie : BaseModel
    {
        public string Title { get; set; }
        public int? Year { get; set; }
        public int? Rate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RuntimeInMinutes { get; set; }
        public string Banner { get; set; }
        public int QuantityInStock { get; set; }
    }
}
