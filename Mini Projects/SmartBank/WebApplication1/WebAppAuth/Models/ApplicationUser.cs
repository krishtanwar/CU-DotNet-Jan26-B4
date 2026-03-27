using Microsoft.AspNetCore.Identity;

namespace WebAppAuth.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
