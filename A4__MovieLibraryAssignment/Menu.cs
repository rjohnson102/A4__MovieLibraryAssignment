using System;
using System.Collections.Generic;
using System.Text;

namespace A4__MovieLibraryAssignment
{
    class Menu
    {
        public Menu()
        {
            
        }               

        public void DisplayMenu()
        {
            Console.WriteLine("1. List All Movies");
            Console.WriteLine("2. Add Movie");
            Console.WriteLine("x to Exit");

                      
        }

        public void Exit()
        {           
            Console.WriteLine("\nGoodbye!");
            Environment.Exit(0);
        }
    }
}
