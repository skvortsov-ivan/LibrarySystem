using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public static class MemberService
    {
        // Create
        public static void CreateMember()
        {
            Console.Write("First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            using var context = new LibrarySystemDbContext();

            var member = new Member
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                FklibraryId = 1 // assuming one library
            };

            context.Members.Add(member);
            context.SaveChanges();

            Console.WriteLine("Member has been created successfully");
        }

        // Read
        public static void ReadMembers()
        {
            using var context = new LibrarySystemDbContext();

            var members = context.Members.ToList();

            Console.WriteLine("\n=== All Members ===");
            foreach (var m in members)
            {
                Console.WriteLine(
                    $"ID: {m.MemberId} | {m.FirstName} {m.LastName} | Email: {m.Email}"
                );
            }
        }

        // Update
        public static void UpdateMember()
        {
            Console.Write("Enter Member ID to update: ");
            int id = int.Parse(Console.ReadLine());

            using var context = new LibrarySystemDbContext();

            var member = context.Members.FirstOrDefault(m => m.MemberId == id);

            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            Console.WriteLine("Leave field empty to keep current value.");

            Console.Write($"First name ({member.FirstName}): ");
            string firstName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(firstName))
                member.FirstName = firstName;

            Console.Write($"Last name ({member.LastName}): ");
            string lastName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(lastName))
                member.LastName = lastName;

            Console.Write($"Email ({member.Email}): ");
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email))
                member.Email = email;

            context.SaveChanges();

            Console.WriteLine("Member updated successfully");
        }

        // Delete
        public static void DeleteMember()
        {
            Console.Write("Enter Member ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            using var context = new LibrarySystemDbContext();

            var member = context.Members.FirstOrDefault(m => m.MemberId == id);

            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            context.Members.Remove(member);
            context.SaveChanges();

            Console.WriteLine("Member deleted successfully");
        }
    }
}



