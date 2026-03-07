namespace StreamBuzzer
{
    class CreatorStats
    {
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }
        public static  List<CreatorStats> EngagementBoard { get; set; }=new List<CreatorStats>();

    }
    internal class Program
    {
        static public void RegisterCreator(CreatorStats record)
        {
            CreatorStats.EngagementBoard.Add(record);
        }
        static public double CalculateAverageLikes()
        {
            double sum = 0;
            int count = 0;
            foreach (var creator in CreatorStats.EngagementBoard)
            {
                foreach (double likes in creator.WeeklyLikes)
                {
                    count++;
                    sum += likes;
                }
            }
            if (count < 0) return 0; 
            return sum / count;
        }
        static public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double LikeThreshold)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var creator in records)
            {
                int count = 0;
                foreach (double likes in creator.WeeklyLikes)
                {
                    if (likes > LikeThreshold)
                        count++;
                }
                if(count > 0)
                result.Add(creator.CreatorName, count);
            }
            return result;
        }
        static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("1. Register Creator");
                Console.WriteLine("2. Show Top Post");
                Console.WriteLine("3. Calculate Average Likes");
                Console.WriteLine("4. Exit");

                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Enter Creator Name: ");
                    string creatorName = Console.ReadLine();
                    double[] weeklyLikes = new double[4];

                    Console.WriteLine("Enter Weekly Likes for 4 weeks:");

                    for (int i = 0; i < 4; i++)
                    {
                        weeklyLikes[i] = (int.Parse(Console.ReadLine()));
                    }

                    CreatorStats creator1 = new CreatorStats()
                    {
                        CreatorName = creatorName,
                        WeeklyLikes = weeklyLikes
                    };
                    RegisterCreator(creator1);
                    Console.WriteLine("Creator registered successfully");
                }

                else if (choice == 2)
                {
                    Console.Write("Enter like threshold: ");
                    double threshold = double.Parse(Console.ReadLine());

                    Dictionary<string, int> result = GetTopPostCounts(CreatorStats.EngagementBoard, threshold);

                    if (result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine(item.Key + "-" + item.Value);
                        }
                    }
                }

                else if (choice == 3)
                {
                    double avg = CalculateAverageLikes();

                    Console.WriteLine("Overall average weekly likes: " + avg);
                }

                else if (choice == 4)
                {
                    Console.WriteLine("Logging off — Keep Creating with StreamBuzz!");
                    break;
                }
            }
        }
    }
}

