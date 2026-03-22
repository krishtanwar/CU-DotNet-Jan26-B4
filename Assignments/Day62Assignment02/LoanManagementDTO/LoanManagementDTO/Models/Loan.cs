using Microsoft.EntityFrameworkCore;

namespace LoanManagementDTO.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public string BorrowerName { get; set; }
        [Precision(18,4)]
        public decimal Amount { get; set; }
        public int LoanTermMonths { get; set; }
        public bool IsApproved { get; set; }
    }
}
