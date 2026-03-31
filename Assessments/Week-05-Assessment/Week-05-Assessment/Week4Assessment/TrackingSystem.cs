using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Week4Assessment
{
    class UnauthorizedAccessException : Exception
    {
        public double W { get; }
        public UnauthorizedAccessException(double weight, string message = null) : base(message ?? $"Unauthorized access for shipment with weight: {weight}")
        {
            W = weight;
        }
    }
    class RestrictedDestinationException : Exception
    {
        public string DeniedLocation { get; }

        public RestrictedDestinationException(string deniedLocation, string message = null)
            : base(message ?? $"Destination '{deniedLocation}' is restricted.")
        {
            DeniedLocation = deniedLocation;
        }
    }

    class InsecurePackagingException : Exception
    {
        public string TrackingId { get; }

        public InsecurePackagingException(string trackingId, string message = null)
            : base(message ?? $"Shipment '{trackingId}' is marked fragile but not reinforced.")
        {
            TrackingId = trackingId;
        }
    }
    abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }
        public bool Fragile { get; }
        public bool Reinforced { get; }

        protected Shipment(string t, double w, string d, bool f, bool r)
        {
            TrackingId = t;
            Weight = w;
            Destination = d;
            Fragile = f;
            Reinforced = r;
        }
        abstract public void ProcessShipment();
    }

    class ExpressShipment : Shipment
    {
        
        string[] restrictedZones =
        {
            "North Pole",
            "South Pole",
            "Unknown Island"
        };

        public ExpressShipment(string t, double w, string d) : base(t, w, d, false, false)
        {
        }

        
        public override void ProcessShipment()
        {
            if(Weight <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Weight), "Shipment weight must be greater than 0.");
            }
            for (int i = 0; i < restrictedZones.Length; i++)
            {
                if (Destination == restrictedZones[i])
                {
                    throw new RestrictedDestinationException(Destination);


                }
            }
                if(Fragile && !Reinforced)
                {
                    throw new InsecurePackagingException(TrackingId);
                }
            
        }
    }
    class HeavyFreight : Shipment
    {
        public bool HasHeavyLiftPermit { get; }

        public HeavyFreight(string trackingId, double weight, string destination, bool hasHeavyLiftPermit = false, bool fragile = false, bool reinforced = false)
            : base(trackingId, weight, destination, fragile, reinforced)
        {
            HasHeavyLiftPermit = hasHeavyLiftPermit;
        }

        public override void ProcessShipment()
        {
            if (Weight<=0)
            {
                throw new ArgumentOutOfRangeException(nameof(Weight), "Shipment weight must be greater than 0.");
            }
            if (Weight > 1000 && !HasHeavyLiftPermit)
            {
                throw new UnauthorizedAccessException(Weight,$"Shipment '{TrackingId}' with weight {Weight} exceeds weight limit for heavy freight without a permit.");
            }
            if (Fragile && !Reinforced)
            {
                throw new InsecurePackagingException(TrackingId);
            }
            if (Destination == "North Pole" || Destination == "South Pole"|| Destination == "Unknown Island")
            {
                throw new RestrictedDestinationException(Destination);
            }
        }
    interface ILoggable
    {
        void SaveLog(string message);
    }
    class LogManager : ILoggable
    {
            string fileName = "../../../shipment_audit.log";
            public void SaveLog(string message)
        {
           
            FileStream file = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.WriteLine($"{DateTime.UtcNow}:{message}");
            }

        }
    }
    internal class TrackingSystem
    {
            static void Main(string[] args)
            {
                
                    LogManager logger = new LogManager();

                    List<Shipment> shipments = new List<Shipment>
                {
                    new ExpressShipment("EXP001", 5, "New York"),
                    new ExpressShipment("EXP002", 0, "Chicago"),
                    new ExpressShipment("EXP003", 750, "South Pole"),
                    new ExpressShipment("EXP004", 2000, "Unknown Island"),
                    new HeavyFreight("FRG001", 1500, "Los Angeles", hasHeavyLiftPermit:true, fragile:true, reinforced:true),
                    new HeavyFreight("FRG002", 2500, "San Francisco", hasHeavyLiftPermit:false, fragile:false, reinforced:false),
                    new HeavyFreight("FRG003", 1500, "North Pole", hasHeavyLiftPermit:true, fragile:true, reinforced:true),
                    new HeavyFreight("FRG004", 3000, "South Pole", hasHeavyLiftPermit:false, fragile:true, reinforced:false)
                };

                    foreach (var shipment in shipments)
                    {
                        try
                        {
                            shipment.ProcessShipment();
                            logger.SaveLog($"SUCCESS: ID:{shipment.TrackingId} processed to '{shipment.Destination}' (Weight: {shipment.Weight}kg).");
                        }
                        catch (RestrictedDestinationException ex)
                        {

                            logger.SaveLog($"SECURITY ALERT: ID:{shipment.TrackingId} DeniedLocation:'{ex.DeniedLocation}' Message:'{ex.Message}'");
                            Console.WriteLine($"Security Alert: Denied Location - {ex.DeniedLocation}");
                        }
                        catch (InsecurePackagingException ex)
                        {
                            logger.SaveLog($"PACKAGING ERROR: ID:{ex.TrackingId} Message:'{ex.Message}'");
                            Console.WriteLine($"Insecure packaging error: {ex.Message}");
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            logger.SaveLog($"DATA ENTRY ERROR: ID:{shipment.TrackingId} Message:'{ex.Message}'");
                            Console.WriteLine($"Data Entry Error: {ex.Message}");
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            logger.SaveLog($"UNAUTHORIZED ACCESS: ID:{shipment.TrackingId} Message:'{ex.Message}'");
                            Console.WriteLine($"Unauthorized Access: {ex.Message}");
                        }
                        catch (Exception ex)
                        {

                            logger.SaveLog($"ERROR: ID:{shipment.TrackingId} Unexpected exception:- {ex.Message}");
                            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                        }
                        finally
                        {
                            Console.WriteLine($"Processing attempt finished for ID:{shipment.TrackingId}");
                        }
                    }
                }
            }
        }
    }


