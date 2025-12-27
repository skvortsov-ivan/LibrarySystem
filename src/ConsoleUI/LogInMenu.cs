using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace LibrarySystem.ConsoleUI
{
    public class LogInMenu
    {
        public static void LogIn()
        {
            // Admin log in menu options 
            List<string> menuOptions = new List<string>
            {
                "Log in"
            };

            while (true)
            {
                int? userInput = DisplayMenu.DisplayAndUseMenu(menuOptions, "Welcome to the library", true);
                switch (userInput)
                {
                    // Admin logs in
                    case 1:
                        using (var context = new LibrarySystemDbContext())
                        {
                            MainMenu.UseMainMenu();
                        }
                        break;

                    // Admin exits library
                    case 0:
                        Console.WriteLine("\nThank you for visiting the library!");
                        return;
                    // Invalid input
                    default:
                        Console.WriteLine("\n Invalid input! Please select an option between 0–1.\n");
                        continue;
                }
            }
        }
    }
}
