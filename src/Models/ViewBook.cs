using System;
using System.Collections.Generic;

namespace LibrarySystem.Models;

public partial class ViewBook
{
    public int BookId { get; set; }

    public string? Author { get; set; }

    public int? PageAmount { get; set; }

    public bool IsAvailable { get; set; }

    public string LibraryName { get; set; } = null!;
}
