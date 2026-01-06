using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Services;

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
                "Show all active loans",
                "Search for a book"
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
                                        MemberService.CreateMember();
                                    }
                                    else if (entity == EntityType.Book)
                                    {
                                        BookService.CreateBook();
                                    }
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadKey();
                                    break;

                                // Read
                                case CrudAction.Read:

                                    if (entity == EntityType.Member)
                                    {
                                        MemberService.ReadMembers();
                                    }
                                    else if (entity == EntityType.Book)
                                    {
                                        BookService.ReadBooks();
                                    }
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadKey();
                                    break;

                                // Update 
                                case CrudAction.Update:

                                    if (entity == EntityType.Member)
                                    {
                                        MemberService.UpdateMember();
                                    }
                                    else if (entity == EntityType.Book)
                                    {
                                        BookService.UpdateBook();
                                    }
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadKey();
                                    break;

                                // Delete
                                case CrudAction.Delete:
                                    if (entity == EntityType.Member)
                                    {
                                        MemberService.DeleteMember();
                                    }
                                    else if (entity == EntityType.Book)
                                    {
                                        BookService.DeleteBook();
                                    }
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        break;
                    // Loan a book
                    case 2:
                        LoanService.BorrowBook();
                        Console.WriteLine("Press Enter to continue\n>");
                        Console.ReadLine();
                        break;
                    // Return a book
                    case 3:
                        LoanService.ReturnBook();
                        Console.WriteLine("Press Enter to continue\n>");
                        Console.ReadLine();
                        break;
                    //Show all active loans"
                    case 4:
                        LoanService.ShowActiveLoans();
                        Console.WriteLine("Press Enter to continue\n>");
                        Console.ReadLine();
                        break;
                    //Search for a book"
                    case 5:
                        SearchService.SearchBooks();
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

