namespace TrackingService.DTOs
{
    public class GpsTrackingDto
    {
        public string TruckId { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
