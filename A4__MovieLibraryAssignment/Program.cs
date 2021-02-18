using System;
using NLog;


namespace A4__MovieLibraryAssignment
{
    class Program
    {
        static Menu menu = new Menu();
        static MovieList movieList = new MovieList();
        static void Main(string[] args)
        {                       
            movieList.PopulateMovieList();
            ReadInInput();
            Logger log = LogManager.GetCurrentClassLogger();       
        }

        public static void ReadInInput()
        {
            bool isParsed = false;
            while (isParsed == false)
            {
                menu.DisplayMenu();

                ConsoleKeyInfo key = Console.ReadKey();

                isParsed = ParseKey(key);
                if (isParsed)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            movieList.ListAllMovies();
                            ReadInInput();
                            break;
                        case ConsoleKey.D2:
                            Movie temp = PromptMovieAdd();
                            movieList.AddMovie(temp);
                            ReadInInput();
                            break;
                        case ConsoleKey.X:
                            menu.Exit();
                            break;
                    }
                }

            }
        }

        public static Movie PromptMovieAdd()
        {
            int id = movieList.GenerateMovieID();
            bool isParsed = false;
            string title = "";
            while (!isParsed)
            {
                Console.WriteLine("\nMovie Title: ");
                title = Console.ReadLine();
                isParsed = ParseString(title);
            }
            

            Console.WriteLine("Movie Genres: ");
            bool isEntering = true;
            string genres = "";
            int count = 2;
            while (isEntering)
            {
                for (int i = 1; i < count; i++)
                {
                    Console.WriteLine("Genre " + i);
                    Console.WriteLine("Press Enter to Continue...");
                    string temp = Console.ReadLine();
                    if (temp != "")
                    {
                        genres += temp + "|";
                        count++;
                    }
                    else
                    {
                        isEntering = false;
                    }
                }
            }
            if(genres == "")
            {
                genres = null;
            }

            Movie movie = new Movie(id, title, genres);
            return movie;
        }

        public static bool ParseString(string title)
        {
            if(title == "")
            {
                return false;
            }
            else
            return true;
        }

        public static bool ParseKey(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.X)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
