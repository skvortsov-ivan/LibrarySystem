using System;
using System.Collections.Generic;

namespace LibrarySystem.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Author { get; set; }

    public int? PageAmount { get; set; }

    public bool IsAvailable { get; set; }

    public int? FklibraryId { get; set; }

    public virtual Library? Fklibrary { get; set; }
}
