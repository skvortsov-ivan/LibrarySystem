CREATE PROCEDURE BorrowBook
    @BookId INT,
    @MemberId INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Book WHERE BookId = @BookId AND IsAvailable = 1)
    BEGIN
        INSERT INTO Loan (FKBookId, FKMemberId)
        VALUES (@BookId, @MemberId);
    END
    ELSE
    BEGIN
        RAISERROR ('Book is not available.', 16, 1);
    END
END;

CREATE PROCEDURE ReturnBook
    @LoanId INT
AS
BEGIN
    UPDATE Loan
    SET ReturnDate = GETDATE()
    WHERE LoanId = @LoanId AND ReturnDate IS NULL;
END;

CREATE PROCEDURE SearchBooks
    @SearchTerm NVARCHAR(100)
AS
BEGIN
    SELECT *
    FROM ViewBooks
    WHERE Author LIKE '%' + @SearchTerm + '%';
END;

--Competetion handling
CREATE PROCEDURE BorrowBookSlow
    @BookId INT,
    @MemberId INT
AS
BEGIN
    BEGIN TRANSACTION;

    -- Lock the book row
    SELECT * FROM Book WITH (ROWLOCK, XLOCK)
    WHERE BookId = @BookId;

    -- Simulate member taking 30 seconds to borrow
    WAITFOR DELAY '00:00:30';

    -- Check availability
    IF EXISTS (SELECT 1 FROM Book WHERE BookId = @BookId AND IsAvailable = 1)
    BEGIN
        INSERT INTO Loan (FKBookId, FKMemberId)
        VALUES (@BookId, @MemberId);
    END
    ELSE
    BEGIN
        ROLLBACK;
        RAISERROR ('Book is not available.', 16, 1);
        RETURN;
    END

    COMMIT;
END;