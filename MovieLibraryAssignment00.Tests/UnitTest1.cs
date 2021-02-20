using System;
using Xunit;


namespace A4__MovieLibraryAssignment
{
    public class UnitTest1
    {
        [Fact]
        public void AddMovieDuplicate_ReturnsFalse()
        {
            Movie movie = new Movie(1, "Toy Story (1995)", "Adventure|Animation|Children|Comedy|Fantasy");
            MovieList movieList = new MovieList();
            bool success = movieList.AddMovie(movie);
            Assert.True(success);
            success = movieList.AddMovie(movie);
            Assert.False(success);
        }               
    }
}
