# Library System – Operating via SQL Server and Visual Studio 2022

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

### 1. Database Configuration

# 1. Navigate to the `LibrarySystem` project folder: `LibrarySystem/LibrarySystem`.
# 2. Create a `appsettings.json` file and include the following syntax. Afterwards change the "INSERTSERVERNAME" to the server name you use in SSMS. 

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


# 3 Open SSMS and create a new database with the name LibrarySystemDB

## ER Diagram
[ER Diagram](docs/LibrarySystemERD_picturev2.png)
Place your PNG file in the repository, either:

- In the root folder  
- Or in a folder named `docs/`

Then include it in the README like this:

If the file is in `docs/`:

```markdown
![ER Diagram](docs/LibrarySystemERD_picturev2.png)


