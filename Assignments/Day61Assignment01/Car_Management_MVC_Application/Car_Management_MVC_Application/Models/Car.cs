using Microsoft.EntityFrameworkCore;

namespace Car_Management_MVC_Application.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        [Precision(18,4)]
        public decimal Price { get; set; }

    }
}
