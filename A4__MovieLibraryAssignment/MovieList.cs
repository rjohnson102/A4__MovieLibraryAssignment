using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace A4__MovieLibraryAssignment
{
    public class MovieList
    {
        public List<Movie> movies;
        public string path = "C:\\Users\\muzic\\source\\repos\\A4__MovieLibraryAssignment\\A4__MovieLibraryAssignment\\movies.csv";

        public MovieList()
        {
            movies = new List<Movie>();
        }

        public void PopulateMovieList()
        {
            
            if (File.Exists(path))
            {
                using (StreamReader file = new StreamReader(path))
                {
                    string line;
                    for (int k = 0; k < 1; k++)
                    {
                        file.ReadLine();
                    }
                    while ((line = file.ReadLine()) != null)
                    {

                        string[] temp = new string[3];
                        
                        line = line.ToString();
                        for (int i = 0; i < temp.Length - 1; i++)
                        {
                            temp = line.Split(',');

                        }
                        
                        int movieID = Convert.ToInt32(temp[0]);
                        Movie movie = new Movie(movieID, temp[1], temp[2]);
                        movies.Add(movie);

                    }
                }
            }
        }

        public void ListAllMovies()
        {
            movies.Sort(delegate (Movie x, Movie y) {
                return x.movieId.CompareTo(y.movieId);
            });
            int i = 0;
            Console.WriteLine();
            foreach (Movie movie in movies)
            {                
                Console.Write(movie.movieId + "\t");
                Console.Write(movie.movieTitle + "\t");
                Console.Write("{0,10}", movie.movieGenre);
                Console.WriteLine();
                i++;
                
                if(i % 20 == 0)
                {
                    Console.WriteLine("Press any key to continue...");
                    ConsoleKeyInfo temp = Console.ReadKey();                   
                }
            }
            
        }

        public int GenerateMovieID()
        {
            Movie movie = movies[movies.Count-1];
            int temp = movie.movieId+1;
            return temp;
        }

        public bool AddMovie(Movie movie)
        {
            int count = 0;
            foreach(Movie mov in movies)
            {
                if (mov.movieTitle.Equals(movie.movieTitle))
                {
                    count++;
                }
                else { count += 0; }
            }
            if(count >= 1)
            {
                Console.WriteLine("Could not add movie: duplicate found");
                return false;
            }
            else
            {
                Console.WriteLine("Movie Added: " + movie.movieTitle);
                movies.Add(movie);
                WriteMoviesToFile();
                return true;
            }
            
        }

        public void WriteMoviesToFile()
        {
            using(StreamWriter outputFile = new StreamWriter(path))
            {
                foreach(Movie movie in movies)
                {
                    string temp = movie.movieId + "," + movie.movieTitle + "," + movie.movieGenre;
                    outputFile.WriteLine(temp);
                }
            }
        }


    }
}
