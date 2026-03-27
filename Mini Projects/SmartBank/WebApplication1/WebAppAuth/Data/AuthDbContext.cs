
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppAuth.Models;

namespace WebAppAuth.Data
{
    public class AuthDbContext:IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options):base(options)
        {
            
        }
    }
}
