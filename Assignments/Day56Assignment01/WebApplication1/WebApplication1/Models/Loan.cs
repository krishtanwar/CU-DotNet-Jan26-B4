using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        [Display(Name ="Borrower Name")]
        [Required]
        public string Borrowername { get; set; }
        public string LenderName { get; set; }
        [Range(1,500000)]
        public double Amount { get; set; }
        public bool IsSettled { get; set; }
    }
}
