--Library table
CREATE TABLE Library (
    LibraryId INT IDENTITY(1,1),
    LibraryName NVARCHAR(100) NOT NULL,
    Adress NVARCHAR(100),
    BookCapacity INT CHECK (BookCapacity >= 0)
);

--Book table
CREATE TABLE Book (
    BookId INT IDENTITY(1,1),
    Author NVARCHAR(50),
    PageAmount INT CHECK (PageAmount > 0),
    IsAvailable BIT NOT NULL DEFAULT 1,
    FKLibraryId INT
);

--Member table
CREATE TABLE Member (
    MemberId INT IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    FKLibraryId INT
);

--Loan table
CREATE TABLE Member (
    LoanId INT IDENTITY(1,1),
    FKBookId INT,
    FKMemberId INT,
    LoanDate DATETIME NOT NULL DEFAULT GETDATE(),
    ReturnDate DATETIME NULL
);
