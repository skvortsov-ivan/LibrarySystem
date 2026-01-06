--View queries
CREATE VIEW ViewBooks AS
SELECT 
    B.BookId,
    B.Author,
    B.PageAmount,
    B.IsAvailable,
    L.LibraryName
FROM Book B
JOIN Library L ON B.FKLibraryId = L.LibraryId;

CREATE VIEW ViewMembers AS
SELECT 
    MemberId,
    FirstName,
    LastName,
    Email,
    FKLibraryId
FROM Member;

CREATE VIEW ViewActiveLoans AS
SELECT 
    L.LoanId,
    B.BookId,
    B.Author,
    M.MemberId,
    M.FirstName,
    M.LastName,
    L.LoanDate
FROM Loan L
JOIN Book B ON L.FKBookId = B.BookId
JOIN Member M ON L.FKMemberId = M.MemberId
WHERE L.ReturnDate IS NULL;