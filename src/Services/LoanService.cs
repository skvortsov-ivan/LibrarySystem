using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.ConsoleUI;
using LibrarySystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public static class LoanService
    {
        public static void BorrowBook()
        {
            using var context = new LibrarySystemDbContext();

            // Step 1: Choose Member
            var members = context.Members
                .Select(m => $"{m.MemberId}. {m.FirstName} {m.LastName}")
                .ToList();

            int? memberChoice = DisplayMenu.DisplayAndUseMenu(
                members,
                "Choose a member",
                false
            );

            if (memberChoice == null || memberChoice == 0)
                return;

            int memberId = int.Parse(members[(int)memberChoice - 1].Split('.')[0]);

            // Step 2: Choose Available Book (IsAvailable == true)
            var availableBooks = context.Books
                .Where(b => b.IsAvailable == true)
                .Select(b => $"{b.BookId}. {b.Author} ({b.PageAmount} pages)")
                .ToList();

            if (!availableBooks.Any())
            {
                Console.WriteLine("No available books at the moment.");
                return;
            }

            int? bookChoice = DisplayMenu.DisplayAndUseMenu(
                availableBooks,
                "Choose a book to borrow",
                false
            );

            if (bookChoice == null || bookChoice == 0)
                return;

            int bookId = int.Parse(availableBooks[(int)bookChoice - 1].Split('.')[0]);

            // Step 3: Execute stored procedure
            var p1 = new SqlParameter("@BookId", bookId);
            var p2 = new SqlParameter("@MemberId", memberId);

            try
            {
                context.Database.ExecuteSqlRaw("EXEC BorrowBook @BookId, @MemberId", p1, p2);
                Console.WriteLine("Loan registered successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void ReturnBook()
        {
            using var context = new LibrarySystemDbContext();

            // Step 1: Choose Member
            var members = context.Members
                .Select(m => $"{m.MemberId}. {m.FirstName} {m.LastName}")
                .ToList();

            int? memberChoice = DisplayMenu.DisplayAndUseMenu(
                members,
                "Choose a member",
                false
            );

            if (memberChoice == null || memberChoice == 0)
                return;

            int memberId = int.Parse(members[(int)memberChoice - 1].Split('.')[0]);

            // Step 2: Get active loans for THIS member only
            var activeLoans = context.Loans
                .Where(l => l.FkmemberId == memberId && l.ReturnDate == null)
                .Include(l => l.Fkbook)
                .ToList();

            if (!activeLoans.Any())
            {
                Console.WriteLine("This member has no active loans.");
                return;
            }

            // Step 3: Build menu of this member's borrowed books
            var loanMenu = activeLoans
                .Select(l => $"{l.LoanId}. {l.Fkbook!.Author} ({l.Fkbook.PageAmount} pages)")
                .ToList();

            int? loanChoice = DisplayMenu.DisplayAndUseMenu(
                loanMenu,
                "Choose a book to return",
                false
            );

            if (loanChoice == null || loanChoice == 0)
                return;

            int loanId = int.Parse(loanMenu[(int)loanChoice - 1].Split('.')[0]);

            // Step 4: Execute stored procedure
            var p1 = new SqlParameter("@LoanId", loanId);

            try
            {
                context.Database.ExecuteSqlRaw("EXEC ReturnBook @LoanId", p1);
                Console.WriteLine("Book returned successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }




        // Show all active loans
        public static void ShowActiveLoans()
        {
            using var context = new LibrarySystemDbContext();

            var loans = context.Loans
                .Where(l => l.ReturnDate == null)
                .Include(l => l.Fkbook)
                .Include(l => l.Fkmember)
                .ToList();

            Console.WriteLine("\n=== Active Loans ===");

            foreach (var loan in loans)
            {
                Console.WriteLine(
                    $"LoanId: {loan.LoanId} | " +
                    $"Book: {loan.Fkbook.Author} | " +
                    $"Member: {loan.Fkmember.FirstName} {loan.Fkmember.LastName} | " +
                    $"LoanDate: {loan.LoanDate}"
                );
            }
        }
    }
}

