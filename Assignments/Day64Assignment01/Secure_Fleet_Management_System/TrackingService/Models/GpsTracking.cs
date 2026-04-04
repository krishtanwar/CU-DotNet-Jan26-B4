namespace TrackingService.Models
{
    public class GpsTracking
    {
        public int Id { get; set; }
        public string TruckId { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
