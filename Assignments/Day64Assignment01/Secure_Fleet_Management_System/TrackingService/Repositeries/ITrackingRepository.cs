using TrackingService.Models;

namespace TrackingService.Repositeries
{
    public interface ITrackingRepository
    {
        List<GpsTracking> GetAll();
        void Add(GpsTracking gps);
    }
}
