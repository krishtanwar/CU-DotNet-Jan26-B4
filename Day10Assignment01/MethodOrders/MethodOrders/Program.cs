namespace MethodOrders
{
    internal class Program
    {
        static void ReadWeeklySales(decimal[] sales)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Enter sales for Day {i + 1}: ");
                    decimal value = Convert.ToDecimal(Console.ReadLine());

                    if (value >= 0)
                    {
                        sales[i] = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Sales cannot be negative.");
                    }
                }
            }
        }

        // 2. Total
        static decimal CalculateTotal(decimal[] sales)
        {
            decimal sum = 0;
            for (int i = 0; i < sales.Length; i++)
            {
                sum += sales[i];
            }
            return sum;
        }

        // 2. Average
        static decimal CalculateAverage(decimal total, int days)
        {
            return total / days;
        }

        // 3. Highest Sale (out)
        static decimal FindHighestSale(decimal[] sales, out int day)
        {
            decimal max = sales[0];
            day = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] > max)
                {
                    max = sales[i];
                    day = i + 1;
                }
            }
            return max;
        }

        // 3. Lowest Sale (out)
        static decimal FindLowestSale(decimal[] sales, out int day)
        {
            decimal min = sales[0];
            day = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] < min)
                {
                    min = sales[i];
                    day = i + 1;
                }
            }
            return min;
        }

        // 4. Discount (overloading)
        static decimal CalculateDiscount(decimal total)
        {
            if (total >= 50000)
                return total * 0.10m;
            else
                return total * 0.05m;
        }

        static decimal CalculateDiscount(decimal total, bool isFestivalWeek)
        {
            decimal discount = CalculateDiscount(total);

            if (isFestivalWeek)
                discount += total * 0.05m;

            return discount;
        }

        // 5. Tax
        static decimal CalculateTax(decimal amount)
        {
            return amount * 0.18m;
        }

        // 6. Final Amount
        static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
        {
            return total - discount + tax;
        }

        // 7. Category Generation
        static void GenerateSalesCategory(decimal[] sales, string[] categories)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000)
                    categories[i] = "Low";
                else if (sales[i] <= 15000)
                    categories[i] = "Medium";
                else
                    categories[i] = "High";
            }
        }

        // Report Method
        static void DisplayReport(decimal total, decimal average,
                                  decimal highest, int highDay,
                                  decimal lowest, int lowDay,
                                  decimal discount, decimal tax,
                                  decimal finalAmount, string[] categories)
        {
            Console.WriteLine("\nWeekly Sales Summary");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Total Sales        : {total:F2}");
            Console.WriteLine($"Average Daily Sale : {average:F2}\n");

            Console.WriteLine($"Highest Sale       : {highest:F2} (Day {highDay})");
            Console.WriteLine($"Lowest Sale        : {lowest:F2}  (Day {lowDay})\n");

            Console.WriteLine($"Discount Applied   : {discount:F2}");
            Console.WriteLine($"Tax Amount         : {tax:F2}");
            Console.WriteLine($"Final Payable      : {finalAmount:F2}\n");

            Console.WriteLine("Day-wise Category:");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"Day {i + 1} : {categories[i]}");
            }
        }
        static void Main(string[] args)
        {
            const int DAYS = 7;

            decimal[] weeklySales = new decimal[DAYS];
            string[] categories = new string[DAYS];

            // 1. Read sales
            ReadWeeklySales(weeklySales);

            // 2. Total and Average
            decimal total = CalculateTotal(weeklySales);
            decimal average = CalculateAverage(total, DAYS);

            // 3. Highest and Lowest
            int highDay, lowDay;
            decimal highest = FindHighestSale(weeklySales, out highDay);
            decimal lowest = FindLowestSale(weeklySales, out lowDay);

            // 4. Discount (overloaded)
            bool isFestivalWeek = true; // can be changed
            decimal discount = CalculateDiscount(total, isFestivalWeek);

            // 5. Tax
            decimal tax = CalculateTax(total - discount);

            // 6. Final Amount
            decimal finalAmount = CalculateFinalAmount(total, discount, tax);

            // 7. Category generation
            GenerateSalesCategory(weeklySales, categories);

            // Output
            DisplayReport(total, average, highest, highDay, lowest, lowDay,
                          discount, tax, finalAmount, categories);
        }
    }
}
