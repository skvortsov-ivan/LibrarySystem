using System;
using System.Collections.Generic;

namespace LibrarySystem.Models;

public partial class Loan
{
    public int LoanId { get; set; }

    public int? FkbookId { get; set; }

    public int? FkmemberId { get; set; }

    public DateTime LoanDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual Book? Fkbook { get; set; }

    public virtual Member? Fkmember { get; set; }
}
