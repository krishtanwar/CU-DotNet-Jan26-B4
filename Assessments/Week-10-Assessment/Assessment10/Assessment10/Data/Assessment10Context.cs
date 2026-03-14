using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assessment10.Models;

namespace Assessment10.Data
{
    public class Assessment10Context : DbContext
    {
        public Assessment10Context (DbContextOptions<Assessment10Context> options)
            : base(options)
        {
        }

        public DbSet<Assessment10.Models.Account> Account { get; set; } = default!;
        public DbSet<Assessment10.Models.Transaction> Transaction { get; set; } = default!;
    }
}
