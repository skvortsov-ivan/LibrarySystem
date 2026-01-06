using System;
using System.Collections.Generic;

namespace LibrarySystem.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? FklibraryId { get; set; }

    public virtual Library? Fklibrary { get; set; }
}
