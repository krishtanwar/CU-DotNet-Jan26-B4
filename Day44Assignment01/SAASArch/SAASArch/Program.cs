namespace SAASArch
{
    abstract class Subscriber
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        public abstract decimal CalculateMonthlyBill();

    }
    class BusinessSubscriber : Subscriber
    {
        decimal fixedRate = 0;
        decimal taxRate = 0;
        public BusinessSubscriber(decimal f,decimal t)
        {
            fixedRate = f;
            taxRate = t;
        }
        public override decimal CalculateMonthlyBill()
        {
            return fixedRate + (fixedRate * taxRate);
        }
    }
    class ConsumerSubscriber : Subscriber
    {
        decimal dataUsageGB = 0;
        decimal pricePerGB = 0;
        public ConsumerSubscriber(decimal d,decimal p)
        {
            dataUsageGB = d;
            pricePerGB = p;
        }
        public override decimal CalculateMonthlyBill()
        {
            return dataUsageGB * pricePerGB;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
