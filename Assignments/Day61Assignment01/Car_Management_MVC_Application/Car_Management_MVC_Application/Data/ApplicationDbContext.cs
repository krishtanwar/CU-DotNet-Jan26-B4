using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Car_Management_MVC_Application.Models;

namespace Car_Management_MVC_Application.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car_Management_MVC_Application.Models.Car> Car { get; set; } = default!;
    }
}
