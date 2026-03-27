using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class CreateAccountDto
    {
        [Required]
        public string Name { get; set; }
        [Range(1000,int.MaxValue,ErrorMessage ="Minimum balance should be 1000")]
        public decimal InitialDeposit { get; set; }
    }
}
