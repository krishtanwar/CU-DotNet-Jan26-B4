namespace BillingSystem
{


    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }

        public string Consumername { get; set; }

        public decimal UnitsConsumed { get; set; }

        public decimal RatePerunit { get; set; }

        

        public abstract decimal CalculateBillAmount();

        public virtual decimal CalculateTax(decimal BillAmount)
        {
            return BillAmount * 0.95m;
        }

        public void PrintBill()
        {
            Console.WriteLine($"Name of the customer: {Consumername}");
            Console.WriteLine($"Consumer Id: {ConsumerId}");
            Console.WriteLine($"Total Units Consumed: {UnitsConsumed}");
            Console.WriteLine($"The final bill amount will be: {CalculateTax(CalculateBillAmount())}");
        }
    }

    class ElectricityBill : UtilityBill
    {

        protected ElectricityBill(int id, string name, decimal u, decimal r)
        {
            ConsumerId = id;
            Consumername = name;
            UnitsConsumed = u;
            RatePerunit = r;
        }
        public override decimal CalculateBillAmount()
        {
            decimal billAmount=UnitsConsumed*RatePerunit;
            if (UnitsConsumed > 300)
            {
                return billAmount * 1.1m;
            }
            else return billAmount;
        }
    }

    class WaterBill : UtilityBill
    {
        protected WaterBill(int id, string name, decimal u, decimal r)
        {
            ConsumerId = id;
            Consumername = name;
            UnitsConsumed = u;
            RatePerunit = r;
        }

        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerunit;
        }
        public override decimal CalculateTax(decimal BillAmount)
        {
            return BillAmount * 0.98m;

        }

      
    }

    class GasBill : UtilityBill
    {
        protected GasBill(int id, string name, decimal u, decimal r)
        {
            ConsumerId = id;
            Consumername = name;
            UnitsConsumed = u;
            RatePerunit = r;
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
