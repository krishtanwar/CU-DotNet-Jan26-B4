namespace Day20Assignment
{

    class Flight:IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }

        public Flight(string n,decimal p,TimeSpan d,DateTime dt)
        {
            FlightNumber = n;
            Price = p;
            Duration = d;
            DepartureTime = dt;
        }
        public int CompareTo(Flight? other)
        {
            return this.Price.CompareTo(other?.Price);
        }
        public override string ToString()
        {
            return $"FlightNumber: {FlightNumber} Price: {Price} Duration: {Duration} DepartureTime: {DepartureTime}";
        }
    }
    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
          return  x.Duration.CompareTo(y?.Duration);
        }
    }
    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.DepartureTime.CompareTo(y?.DepartureTime);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Flight> list = new List<Flight>()
            {
                new Flight("BC123",2030,new TimeSpan(1,30,0),DateTime.Parse("2026-01-30 5:30")),
                 new Flight("BC12345",1600,new TimeSpan(2,30,0),DateTime.Parse("2026-01-30 2:30")),
                  new Flight("BC1234",5000,new TimeSpan(1,10,0),DateTime.Parse("2026-01-31 10:30"))
            };

            list.Sort();
            Console.WriteLine("1. Economic View: Cheapest flights at the top");
            foreach (Flight f1 in list)
            {
                Console.WriteLine(f1);
            }
            Console.WriteLine();

            list.Sort(new DurationComparer());
            Console.WriteLine("2. Business Runner View: Shortest flights at the top.");
            foreach (var f1 in list)
            {
                Console.WriteLine(f1);
            }
            Console.WriteLine();

            list.Sort(new DepartureComparer());
            Console.WriteLine("3. Early Bird View: Earliest departing flights at the top.");
            foreach (var f1 in list)
            {
                Console.WriteLine(f1);
            }
        }
    }
}
