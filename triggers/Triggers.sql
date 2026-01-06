CREATE TRIGGER trg_BookBorrowed
ON Loan
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE B
    SET B.IsAvailable = 0
    FROM Book B
    INNER JOIN inserted I ON B.BookId = I.FKBookId;
END;

CREATE TRIGGER trg_BookReturned
ON Loan
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE B
    SET B.IsAvailable = 1
    FROM Book B
    INNER JOIN inserted I ON B.BookId = I.FKBookId
    WHERE I.ReturnDate IS NOT NULL;
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