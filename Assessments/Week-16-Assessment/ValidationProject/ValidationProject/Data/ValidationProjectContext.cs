using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValidationProject.Models;

namespace ValidationProject.Data
{
    public class ValidationProjectContext : DbContext
    {
        public ValidationProjectContext (DbContextOptions<ValidationProjectContext> options)
            : base(options)
        {
        }

        public DbSet<ValidationProject.Models.Course> Courses { get; set; } = default!;
    }
}
