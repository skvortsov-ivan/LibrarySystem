--Adding primary key constraints
ALTER TABLE Library
ADD CONSTRAINT PK_Library PRIMARY KEY (LibraryId);

ALTER TABLE Book
ADD CONSTRAINT PK_Book PRIMARY KEY (BookId);

ALTER TABLE Member
ADD CONSTRAINT PK_Member PRIMARY KEY (MemberId);

ALTER TABLE Loan
ADD CONSTRAINT PK_Loan PRIMARY KEY (LoanId);

--Adding foreign key constraints
ALTER TABLE Book
ADD CONSTRAINT FK_Book_Library
FOREIGN KEY (FKLibraryId) REFERENCES Library(LibraryId);

ALTER TABLE Member
ADD CONSTRAINT FK_Member_Library
FOREIGN KEY (FKLibraryId) REFERENCES Library(LibraryId);

ALTER TABLE Loan
ADD CONSTRAINT FK_Loan_Book
FOREIGN KEY (FKBookId) REFERENCES Book(BookId)

ALTER TABLE Loan
ADD CONSTRAINT FK_Loan_Member
FOREIGN KEY (FKMemberId) REFERENCES Member(MemberId)