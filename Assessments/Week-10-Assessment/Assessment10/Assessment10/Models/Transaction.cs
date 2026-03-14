using System.Security.Principal;

namespace Assessment10.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }

        public string Category { get; set; }

        public DateTime Date { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
