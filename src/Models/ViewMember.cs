using System;
using System.Collections.Generic;

namespace LibrarySystem.Models;

public partial class ViewMember
{
    public int MemberId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? FklibraryId { get; set; }
}
