using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string? AccountNumber { get; set; }
        public string Name { get; set; }
        [Precision(18,4)]
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
