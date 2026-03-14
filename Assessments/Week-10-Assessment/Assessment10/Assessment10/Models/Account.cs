using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Assessment10.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string AccountName { get; set; }

        public double Balance { get; set; }
        [ValidateNever]
        public List<Transaction> Transactions { get; set; }=new List<Transaction>();
    }
}
