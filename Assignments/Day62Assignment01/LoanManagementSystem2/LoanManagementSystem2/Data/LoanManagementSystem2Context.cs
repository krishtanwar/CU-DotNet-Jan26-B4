using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanManagementSystem2.Models;

namespace LoanManagementSystem2.Data
{
    public class LoanManagementSystem2Context : DbContext
    {
        public LoanManagementSystem2Context (DbContextOptions<LoanManagementSystem2Context> options)
            : base(options)
        {
        }

        public DbSet<LoanManagementSystem2.Models.Loan> Loan { get; set; } = default!;
    }
}
