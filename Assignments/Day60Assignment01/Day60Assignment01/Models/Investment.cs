using Microsoft.EntityFrameworkCore;

namespace Day60Assignment01.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public string TickerSymbol { get; set; } // e.g., "SILVERBEES"
        public string AssetName { get; set; }
        [Precision(18,4)]
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
