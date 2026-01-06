using System;
using System.Collections.Generic;

namespace LibrarySystem.Models;

public partial class ViewActiveLoan
{
    public int LoanId { get; set; }

    public int BookId { get; set; }

    public string? Author { get; set; }

    public int MemberId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime LoanDate { get; set; }
}
