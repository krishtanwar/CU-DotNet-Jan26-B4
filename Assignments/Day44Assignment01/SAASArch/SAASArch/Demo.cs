
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaaSArchitect
{
    // 1. ABSTRACT BASE CLASS
    public abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        public abstract decimal CalculateMonthlyBill();

        // 2. EQUALITY (based on ID)
        

       

        // 2. COMPARABLE (JoinDate then Name)
       
    }

    // BUSINESS SUBSCRIBER
    public class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1 + TaxRate);
        }
    }

    // CONSUMER SUBSCRIBER
    public class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }
    }

    // 4. REPORT GENERATOR
    public static class ReportGenerator
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------------------------------------------------");
            sb.AppendLine("TYPE\t\tNAME\t\tBILL");
            sb.AppendLine("---------------------------------------------------");

            foreach (var s in subscribers)
            {
                string type = s is BusinessSubscriber ? "Business" : "Consumer";
                sb.AppendLine($"{type}\t\t{s.Name}\t\t{s.CalculateMonthlyBill():C}");
            }

            sb.AppendLine("---------------------------------------------------");
            Console.WriteLine(sb.ToString());
        }
    }

    class Program
    {
        static void Main()
        {
            // 3. DICTIONARY (Email -> Subscriber)
            Dictionary<string, Subscriber> subscribers = new Dictionary<string, Subscriber>();

            subscribers.Add("a@company.com", new BusinessSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Alpha Corp",
                JoinDate = new DateTime(2023, 1, 10),
                FixedRate = 1000,
                TaxRate = 0.18m
            });

            subscribers.Add("b@company.com", new BusinessSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Beta Corp",
                JoinDate = new DateTime(2023, 3, 5),
                FixedRate = 1500,
                TaxRate = 0.15m
            });

            subscribers.Add("c@gmail.com", new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Charlie",
                JoinDate = new DateTime(2023, 2, 20),
                DataUsageGB = 50,
                PricePerGB = 5
            });

            subscribers.Add("d@gmail.com", new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "David",
                JoinDate = new DateTime(2023, 4, 1),
                DataUsageGB = 70,
                PricePerGB = 4
            });

            subscribers.Add("e@gmail.com", new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Emma",
                JoinDate = new DateTime(2023, 1, 15),
                DataUsageGB = 40,
                PricePerGB = 6
            });

            // SORT BY MONTHLY BILL (DESCENDING)
            var sortedSubscribers = subscribers
                .OrderByDescending(x => x.Value.CalculateMonthlyBill())
                .Select(x => x.Value)
                .ToList();

            // PRINT REPORT
            ReportGenerator.PrintRevenueReport(sortedSubscribers);
        }
    }
}
