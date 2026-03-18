using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Day60Assignment01.Models;

namespace Day60Assignment01.Data
{
    public class Day60Assignment01Context : DbContext
    {
        public Day60Assignment01Context (DbContextOptions<Day60Assignment01Context> options)
            : base(options)
        {
        }

        public DbSet<Day60Assignment01.Models.Investment> Investment { get; set; } = default!;
    }
}
