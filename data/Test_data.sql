USE LibrarySystemDB; 

--Insert into Library
INSERT INTO Library (LibraryName, Adress, BookCapacity)
VALUES ('Central City Library', 'Stockholm', 500);

--Insert into Member
INSERT INTO Member (FirstName, LastName, Email, FKLibraryId)
VALUES 
('Anna', 'Svensson', 'anna.svensson@example.com', 1),
('Markus', 'Lindgren', 'markus.lindgren@example.com', 1),
('Elin', 'Johansson', 'elin.johansson@example.com', 1);

--Insert into Book
INSERT INTO Book (Author, PageAmount, IsAvailable, FKLibraryId)
VALUES
('J.R.R. Tolkien', 423, 1, 1),
('George Orwell', 328, 1, 1),
('Jane Austen', 279, 1, 1),
('Isaac Asimov', 255, 1, 1),
('Mary Shelley', 310, 1, 1),
('Agatha Christie', 198, 1, 1),
('Stephen King', 512, 1, 1),
('Haruki Murakami', 384, 1, 1),
('Brandon Sanderson', 1007, 1, 1),
('C.S. Lewis', 208, 1, 1);

-- Insert into Loan
INSERT INTO Loan (BookId, MemberId, LoanDate, ReturnDate)
VALUES
(1, 1, DATEADD(day, -1, GETDATE()), NULL),
(2, 2, DATEADD(day, -3, GETDATE()), NULL),
(3, 3, GETDATE(), NULL),
(4, 1, DATEADD(day, -7, GETDATE()), GETDATE());