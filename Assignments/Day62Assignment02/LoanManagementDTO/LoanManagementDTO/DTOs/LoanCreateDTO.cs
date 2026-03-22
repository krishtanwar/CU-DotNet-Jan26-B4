namespace LoanManagementDTO.DTOs
{
    public class LoanCreateDTO
    {
        public string BorrowerName { get; set; }

        public decimal Amount { get; set; }
        public int LoanTermMonths { get; set; }
        public bool IsApproved { get; set; }
    }
}
