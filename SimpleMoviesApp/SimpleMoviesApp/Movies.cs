using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMoviesApp
{
    internal class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string YearOfRelease { get; set; }
        public string Genre { get; set; }

        public Movies(int id, string name, string yearOfRelease, string genre)
        {
            Id = id;
            Name = name;
            YearOfRelease = yearOfRelease;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"Movie Id: {Id}, Movie Name: {Name}, Genre: {Genre}, YearOfRelease: {YearOfRelease}";
        }
    }
}

