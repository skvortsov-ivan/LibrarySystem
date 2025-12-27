using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.ConsoleUI
{
    public static class MainMenu
    {
        public enum CrudAction
        {
            Create = 1,
            Read = 2,
            Update = 3,
            Delete = 4
        };

        public enum EntityType
        {
            Member = 1,
            Book = 2,
        };

        public static void UseMainMenu()
        {
            // Main menu options 
            List<string> menuOptions = new List<string>
            {
                "CRUD-operations",
                "Loan a book",
                "Return a book",
                "Search for a book",
                "Show all active loans"
            };

            // Crud menu options 
            List<string> crudMenuOptions = new List<string>
            {
                "Create",
                "Read",
                "Update",
                "Delete"
            };

            // Entity menu options
            List<string> entityMenuOptions = new List<string>
            {
                "Member",
                "Book",
            };


            while (true)
            {
                bool exitMenu = false;
                int? userInput = DisplayMenu.DisplayAndUseMenu(menuOptions, "Main menu", true);
                switch (userInput)
                {
                    // CRUD
                    case 1:
                        while (!exitMenu)
                        {
                            int? userCrudInput = DisplayMenu.DisplayAndUseMenu(crudMenuOptions, "Choose CRUD action", false);

                            if (userCrudInput == 0)
                            {
                                exitMenu = true;
                                break;
                            }

                            CrudAction action = (CrudAction)userCrudInput;

                            int? userEntityInput = DisplayMenu.DisplayAndUseMenu(entityMenuOptions, "Choose entity", false);
                            if (userEntityInput == null || userEntityInput == 0) continue;

                            EntityType entity = (EntityType)userEntityInput;

                            switch (action)
                            {
                                // Create
                                case CrudAction.Create:

                                    if (entity == EntityType.Member)
                                    {

                                    }
                                    else if (entity == EntityType.Book)
                                    {

                                    }
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadKey();
                                    break;

                                // Read
                                case CrudAction.Read:

                                    if (entity == EntityType.Member)
                                    {

                                    }
                                    else if (entity == EntityType.Book)
                                    {

                                    }
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadKey();
                                    break;

                                // Update 
                                case CrudAction.Update:

                                    if (entity == EntityType.Member)
                                    {

                                    }
                                    else if (entity == EntityType.Book)
                                    {

                                    }
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadKey();
                                    break;

                                // Delete
                                case CrudAction.Delete:
                                    if (entity == EntityType.Member)
                                    {

                                    }
                                    else if (entity == EntityType.Book)
                                    {

                                    }
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        break;
                    // Loan a book
                    case 2:
                        Console.WriteLine("Press Enter to continue\n>");
                        Console.ReadLine();
                        break;
                    // Return a book
                    case 3:
                        Console.WriteLine("Press Enter to continue\n>");
                        Console.ReadLine();
                        break;
                    //Search for a book"
                    case 4:
                        Console.WriteLine("Press Enter to continue\n>");
                        Console.ReadLine();
                        break;
                    //Show all active loans"
                    case 5:
                        Console.WriteLine("Press Enter to continue\n>");
                        Console.ReadLine();
                        break;
                    // Admin exits main menu
                    case 0:
                        return;
                    // Invalid input
                    default:
                        Console.WriteLine("\n Invalid input! Please an option between 0–3.\n");
                        continue;
                }
            }
        }
    }
}

