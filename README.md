# Library System – Student project in SSMS and Visual Studio

This project is a console-based library system that manages books, members, and loans. This is a student project designed for the student to learn how to implement database first, scaffolding and many other basic operations such as views, procedures, triggers, indexing and more. 

---

## Short Description

The library system models a real-world library where:

- Books can be registered, updated, borrowed, and returned  
- Members can be registered and manage their loans  
- Loans are created when a member borrows a book and closed when the book is returned  
- Search functionality allows users to find books based on author or title  
- A Library acts as an organizational unit that books and members belong to  

The system uses a menu-driven structure where the user can:

- Perform CRUD operations on both members and books   
- Borrow books 
- Return books
- View all active loans  
- Search for books  

---

## Prerequisites

Before running the application, ensure you have the following installed:

* **SQL Server Management Studio (SSMS)** (2021 or later)
* **Visual Studio 2022** (or later)
* **.NET SDK** (compatible with the project version)
* **SQL Server** (LocalDB or full version)

---

## Setup & Installation  

1. Navigate to the `LibrarySystem` project folder: `LibrarySystem/LibrarySystem`.  
2. Create a `appsettings.json` file and include the following syntax. Afterwards change the "INSERTSERVERNAME" to the server name you use in SSMS.  

   ```json
   {
    "ConnectionStrings": {
        "DefaultConnection": "Server=INSERTSERVERNAME;Database=LibrarySystemDB;Trusted_Connection=True;MultipleActiveResultSets=true"
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*"
    }
   ```

3. Open SSMS and create a new database with the name LibrarySystemDB  

## ER Diagram  
The ER diagram provides an overview of the core entities in the system and how they relate to each other.  
It illustrates the one‑to‑many relationships between Library–Book, Member–Loan, and Book–Loan, forming the foundation of the system’s data structure.  
This visual model helps clarify how data flows through the application and ensures that the database design supports all required operations.  
It also serves as a reference when implementing stored procedures, triggers, and constraints to maintain data integrity.

You can find it here:
[ER Diagram](docs/LibrarySystemERD.png)

## Full Database Script

A complete SQL Server script for the entire database schema is included in this repository.  
This script contains all tables, primary keys, foreign keys, views, triggers, and stored procedures used by the application.  

You can find it here:  

/FullScript/FullScript.sql 

How to Use the Script

    Open SQL Server Management Studio (SSMS).

    Connect to your SQL Server server.

    Open the file FullScript.sql .

    Execute the script.

## Transaction Handling & Concurrency Control

To ensure data integrity and correct handling of simultaneous loan attempts, the system uses transactions inside its stored procedures. A transaction groups multiple SQL operations into a single unit of work, meaning everything is either committed together or fully rolled back if something goes wrong. This prevents the database from ending up in an inconsistent state.

In the `BorrowBookSlow` procedure, a transaction is combined with row‑level locking (ROWLOCK, XLOCK) to simulate two members trying to borrow the same book at the same time. The first transaction locks the book and intentionally waits, while the second transaction becomes blocked until the lock is released. When the first transaction commits, the second one fails because the book is no longer available, demonstrating that SQL Server correctly handles concurrency and prevents double bookings.


To show concurrency and locking behavior:

1. Open **two separate query windows** in SQL Server Management Studio (SSMS), both connected to the `LibrarySystemDB` database.
2. Run the syntax below in the first window. This will execute the stored procedure BorrowBookSlow which will demonstrate transaction isolation. The result should be like in this picture [Competetive1](docs/Competetive1.png)

   ```sql
   EXEC BorrowBookSlow @BookId = 7, @MemberId = 1;
3. Run the same command in the second window. The result should be like in this picture [Competetive2](docs/Competetive2.png).
4. Running the same command in the second window will be blocked due to the locking behavior inside the procedure. When the procedure is finished running the result should be like in this picture [Competetive3](docs/Competetive3.png)

