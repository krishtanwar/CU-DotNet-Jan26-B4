using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.DTOs
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        [AllowNull]
        public string AccountNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1000, int.MaxValue, ErrorMessage = "Minimum balance should be 1000")]
        public decimal Balance { get; set; }

    }
}
