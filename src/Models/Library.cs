using System;
using System.Collections.Generic;

namespace LibrarySystem.Models;

public partial class Library
{
    public int LibraryId { get; set; }

    public string LibraryName { get; set; } = null!;

    public string? Adress { get; set; }

    public int? BookCapacity { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
