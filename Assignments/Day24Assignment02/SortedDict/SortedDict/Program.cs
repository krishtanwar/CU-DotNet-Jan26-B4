using System;

namespace SortedDict
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, string> leaderboard = new SortedDictionary<double, string>();
            leaderboard.Add(55.42, "SwiftRacer");
            leaderboard.Add(52.10, "SpeedDemon");
            leaderboard.Add(58.91, "SteadyEddie");
            leaderboard.Add(51.05, "TurboTom");

            foreach(var item in leaderboard)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine($"The Topper of the Leaderboard is: {leaderboard.First()}");

            double val = -1;
            foreach (var item in leaderboard)
            {
                
                if(item.Value=="SteadyEddie") val=item.Key;


            }
            if (val != -1)
            {
                leaderboard.Remove(val);
                leaderboard.Add(54.00, "SteadyEddie");
            }

            Console.WriteLine("After Updation: ");

            foreach (var item in leaderboard)
            {
                Console.WriteLine(item);
            }
        }
    }
}
