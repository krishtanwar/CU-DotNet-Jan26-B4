using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Back_End.Models;

namespace Back_End.Data
{
    public class Back_EndContext : DbContext
    {
        public Back_EndContext (DbContextOptions<Back_EndContext> options)
            : base(options)
        {
        }

        public DbSet<Back_End.Models.Destination> Destinations { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Destination>().Property(p=>p.CityName).IsRequired();
            modelBuilder.Entity<Destination>().Property(p => p.Country).IsRequired();
            modelBuilder.Entity<Destination>().Property(p => p.Description).HasMaxLength(200);
          //  modelBuilder.Entity<Destination>().Property(p => p.Rating).
            modelBuilder.Entity<Destination>().Property(p => p.Rating).HasDefaultValue(3);
        }
    }
}
