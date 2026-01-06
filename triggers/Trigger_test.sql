-- Trigger test:

-- Borrow Book 4 (Member 1)
INSERT INTO Loan (FKBookId, FKMemberId)
VALUES (4, 1);

-- Check if trigger updated IsAvailable to 0
SELECT BookId, Author, IsAvailable
FROM Book
WHERE BookId = 4;

-- We find the LoanId
SELECT TOP 1 LoanId, FKBookId, ReturnDate 
FROM Loan 
WHERE FKBookId = 4 
ORDER BY LoanId DESC;

-- Input the found LoanId instead of X
UPDATE Loan 
SET ReturnDate = GETDATE() 
WHERE LoanId = X;

-- Check if IsAvailable has become 1 again.
SELECT BookId, Author, IsAvailable 
FROM Book 
WHERE BookId = 4;