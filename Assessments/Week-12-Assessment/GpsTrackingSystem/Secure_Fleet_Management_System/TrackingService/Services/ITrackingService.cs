using TrackingService.DTOs;

namespace TrackingService.Services
{
    public interface ITrackingService
    {
        List<GpsTrackingDto> GetAll();
        void Add(CreateGpsDto dto);
    }
}
