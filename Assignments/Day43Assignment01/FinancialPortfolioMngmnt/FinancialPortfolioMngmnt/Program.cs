using System.Threading.Channels;

namespace FinancialPortfolioMngmnt
{
    class InvalidfinancialDataException : Exception
    {
        public InvalidfinancialDataException()
        {
            Console.WriteLine(Message);
        }
    }
    public class instrument
    {
      

       
    }
    abstract class FinancialInstrument
    {
        public int InstrumentId { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public double MarketPrice { get; set; }
        public abstract decimal CalculateCurrentValue();

        public virtual string GetInstrumentSummary()
        {

        }
        public FinancialInstrument(int id, string n, string c, DateOnly p, int q, double pp, double m)
        {
            InstrumentId = id;
            Name = n;
            Currency = c;
            PurchaseDate = p;
            Quantity = q;
            PurchasePrice = pp;
            MarketPrice = m;

        }
    }
    interface IRiskAssessable
    {
        string GetRiskCategory();
    }
    interface IReportable
    {
        string GenerateReportLine();
    }
    class Portfolio
    {
        List<FinancialInstrument> instruments= new List<FinancialInstrument>
        {
            new FinancialInstrument()
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
