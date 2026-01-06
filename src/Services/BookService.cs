using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public static class BookService
    {
        // Create
        public static void CreateBook()
        {
            Console.Write("Author: ");
            string author = Console.ReadLine();

            Console.Write("Amount of pages: ");
            int pages = int.Parse(Console.ReadLine());

            using var context = new LibrarySystemDbContext();

            var book = new Book
            {
                Author = author,
                PageAmount = pages,
                IsAvailable = true,
                FklibraryId = 1
            };

            context.Books.Add(book);
            context.SaveChanges();

            Console.WriteLine("Book has been created successfully");
        }

        // Read
        public static void ReadBooks()
        {
            using var context = new LibrarySystemDbContext();

            var books = context.Books.ToList();

            Console.WriteLine("\n=== All Books ===");
            foreach (var b in books)
            {
                Console.WriteLine(
                    $"ID: {b.BookId} | Author: {b.Author} | Pages: {b.PageAmount} | Available: {(b.IsAvailable ? "Yes" : "No")}"
                );
            }
        }

        // Update
        public static void UpdateBook()
        {
            Console.Write("Enter Book ID to update: ");
            int id = int.Parse(Console.ReadLine());

            using var context = new LibrarySystemDbContext();

            var book = context.Books.FirstOrDefault(b => b.BookId == id);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.WriteLine("Leave field empty to keep current value.");

            Console.Write($"Author ({book.Author}): ");
            string author = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(author))
                book.Author = author;

            Console.Write($"Pages ({book.PageAmount}): ");
            string pagesInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(pagesInput) && int.TryParse(pagesInput, out int pages))
                book.PageAmount = pages;

            Console.Write($"Available ({(book.IsAvailable ? "Yes" : "No")}): ");
            string availableInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(availableInput))
            {
                if (availableInput.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    book.IsAvailable = true;
                else if (availableInput.Equals("no", StringComparison.OrdinalIgnoreCase))
                    book.IsAvailable = false;
            }

            context.SaveChanges();

            Console.WriteLine("Book updated successfully");
        }

        // Delete
        public static void DeleteBook()
        {
            Console.Write("Enter Book ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            using var context = new LibrarySystemDbContext();

            var book = context.Books.FirstOrDefault(b => b.BookId == id);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            context.Books.Remove(book);
            context.SaveChanges();

            Console.WriteLine("Book deleted successfully");
        }
    }
}




