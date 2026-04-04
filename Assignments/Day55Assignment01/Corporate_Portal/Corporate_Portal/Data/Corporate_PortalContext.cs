using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Corporate_Portal.Models;

namespace Corporate_Portal.Data
{
    public class Corporate_PortalContext : DbContext
    {
        public Corporate_PortalContext (DbContextOptions<Corporate_PortalContext> options)
            : base(options)
        {
        }

        public DbSet<Corporate_Portal.Models.Employee> Employee { get; set; } = default!;
    }
}
