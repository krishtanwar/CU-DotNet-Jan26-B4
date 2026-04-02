using System;
using System.Collections.Generic;

namespace DBFirstSerilog.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public decimal? Price { get; set; }

    public int AuthorId { get; set; }

    
}
