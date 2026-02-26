namespace GymCharges
{
    internal class Program
    {
        public static double CalculateMembershipAmount(bool treadmill, bool weightLifting, bool zumba)
        {
            double total = 1000; // fixed monthly charge
            int serviceCount = 0;

            if (treadmill)
            {
                total += 300;
                serviceCount++;
            }

            if (weightLifting)
            {
                total += 500;
                serviceCount++;
            }

            if (zumba)
            {
                total += 250;
                serviceCount++;
            }

            
            if (serviceCount == 0)
            {
                total += 200;
            }

            
            double gst = total * 0.05;
            total += gst;

            return total;
        }
        static void Main(string[] args)
        {
            double amount = CalculateMembershipAmount(true, false, true);
            Console.WriteLine("Total Amount = Rs. " + amount);
        }
    }
}
