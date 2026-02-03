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

            leaderboard.Remove(58.91);

            leaderboard.Add(54, "SteadyEddie");
            Console.WriteLine("-------------------------");

            Console.WriteLine("After Updation: ");

            foreach (var item in leaderboard)
            {
                Console.WriteLine(item);
            }
        }
    }
}
