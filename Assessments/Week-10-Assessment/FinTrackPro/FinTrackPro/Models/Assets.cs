namespace FinTrackPro.Models
{
    public class Assets
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public double TotalValue => Price * Quantity;
    }
}
