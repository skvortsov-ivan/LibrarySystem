using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibrarySystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class SearchService
    {
        // Search for books
        public static void SearchBooks()
        {
            Console.Write("Search term: ");
            string term = Console.ReadLine();

            using var context = new LibrarySystemDbContext();

            var searchInput = new SqlParameter("@SearchTerm", term);

            var results = context.ViewBooks
                .FromSqlRaw("EXEC SearchBooks @SearchTerm", searchInput)
                .ToList();

            Console.WriteLine("\n=== Search Results ===");

            foreach (var b in results)
            {
                Console.WriteLine(
                    $"ID: {b.BookId} | " +
                    $"Author: {b.Author} | " +
                    $"Available: {(b.IsAvailable ? "Yes" : "No")}"
                );
            }
        }
    }
}

