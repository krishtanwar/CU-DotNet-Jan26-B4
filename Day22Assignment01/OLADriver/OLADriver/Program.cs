namespace OLADriver
{
    class Ride
    {
        public int RideID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Fare { get; set; }
    }
    class OLADriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleNo { get; set; }

      
        public List<Ride> Rides { get; set; } = new List<Ride>();

       
        public decimal GetTotalFare()
        {
            decimal total = 0;
            foreach (Ride r in Rides)
            {
                total += r.Fare;
            }
            return total;
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                List<OLADriver> drivers = new List<OLADriver>();

                
                OLADriver d1 = new OLADriver
                {
                    Id = 1,
                    Name = "Rahul",
                    VehicleNo = "MH12AB1234"
                };

                d1.Rides.Add(new Ride { RideID = 101, From = "Pune", To = "Mumbai", Fare = 1500 });
                d1.Rides.Add(new Ride { RideID = 102, From = "Mumbai", To = "Nashik", Fare = 1200 });

                
                OLADriver d2 = new OLADriver
                {
                    Id = 2,
                    Name = "Amit",
                    VehicleNo = "DL01CD5678"
                };

                d2.Rides.Add(new Ride { RideID = 201, From = "Delhi", To = "Noida", Fare = 500 });
                d2.Rides.Add(new Ride { RideID = 202, From = "Noida", To = "Gurgaon", Fare = 700 });
                d2.Rides.Add(new Ride { RideID = 203, From = "Gurgaon", To = "Delhi", Fare = 800 });

                drivers.Add(d1);
                drivers.Add(d2);

              
                DisplayDrivers(drivers);
            }

            static void DisplayDrivers(List<OLADriver> drivers)
            {
                foreach (OLADriver d in drivers)
                {
                    Console.WriteLine("\nDriver ID   : " + d.Id);
                    Console.WriteLine("Name        : " + d.Name);
                    Console.WriteLine("Vehicle No  : " + d.VehicleNo);
                    Console.WriteLine("Rides:");

                    foreach (Ride r in d.Rides)
                    {
                        Console.WriteLine($"   RideID: {r.RideID}, From: {r.From}, To: {r.To}, Fare: {r.Fare}");
                    }

                    Console.WriteLine("Total Fare: " + d.GetTotalFare());
                }
            }
        }
    }
}
