namespace SAASArch
{
    abstract class Subscriber
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        public abstract decimal CalculateMonthlyBill();

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Subscriber other)
                return this.Id == other.Id;
            return false;
        }
        public int CompareTo(Subscriber other)
        {
            int dateCompare = this.JoinDate.CompareTo(other.JoinDate);
            if (dateCompare == 0)
                return this.Name.CompareTo(other.Name);
            return dateCompare;
        }

    }
    class BusinessSubscriber : Subscriber
    {
        public decimal fixedRate {  get; set; }
        public decimal taxRate { get; set; }
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
       public decimal dataUsageGB {  get; set; }
       public decimal pricePerGB {  get; set; }
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
