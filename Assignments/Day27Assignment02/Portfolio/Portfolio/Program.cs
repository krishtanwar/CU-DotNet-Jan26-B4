namespace Portfolio
{
    public class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "loans.csv";

            Console.Write("Enter Client Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Principal Amount: ");
            string principalInput = Console.ReadLine();

            Console.Write("Enter Interest Rate: ");
            string rateInput = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine("ClientName,Principal,InterestRate");
                }
            }

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{name},{principalInput},{rateInput}");
            }

            Console.WriteLine("\nLoan saved successfully.\n");

            List<Loan> loans = new List<Loan>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine(); 

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (double.TryParse(parts[1], out double principal) &&
                        double.TryParse(parts[2], out double rate))
                    {
                        loans.Add(new Loan
                        {
                            ClientName = parts[0],
                            Principal = principal,
                            InterestRate = rate
                        });
                    }
                }
            }

            Console.WriteLine("CLIENT     | PRINCIPAL      | INTEREST       | RISK LEVEL");
            Console.WriteLine("---------------------------------------------------------------");

            foreach (var loan in loans)
            {
                double interestAmount = loan.Principal * loan.InterestRate / 100;

                string risk;
                if (loan.InterestRate > 10)
                    risk = "HIGH";
                else if (loan.InterestRate >= 5)
                    risk = "MEDIUM";
                else
                    risk = "LOW";

                Console.WriteLine("{0,-10} | {1,13:C} | {2,13:C} | {3}",
                    loan.ClientName,
                    loan.Principal,
                    interestAmount,
                    risk);
            }

            Console.ReadLine();
        }
    }
}
