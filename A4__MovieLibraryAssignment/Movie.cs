using System;
using System.Collections.Generic;
using System.Text;

namespace A4__MovieLibraryAssignment
{
    class Movie
    {
        public int movieId { get; set; }
        public string movieTitle { get; set; }

        public string movieGenre { get; set; }

        public Movie(int movieID, string movieTitle, string movieGenre)
        {
            this.movieId = movieID;
            this.movieTitle = movieTitle;
            this.movieGenre = movieGenre;
        }      
        override
        public string ToString()
        {
            string temp = "";
            temp += movieId + ", " + movieTitle + ", " + movieGenre;
            return temp;
        }
    }
}
