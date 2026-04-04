using TrackingService.DTOs;
using TrackingService.Models;
using TrackingService.Repositeries;

namespace TrackingService.Services
{
    public class TrackingServices:ITrackingService
    {
        private readonly ITrackingRepository _repo;

        public TrackingServices(ITrackingRepository repo)
        {
            _repo = repo;
        }

        public List<GpsTrackingDto> GetAll()
        {
            var data = _repo.GetAll();

            return data.Select(x => new GpsTrackingDto
            {
                TruckId = x.TruckId,
                Location = x.Location,
                Timestamp = x.Timestamp
            }).ToList();
        }

        public void Add(CreateGpsDto dto)
        {
            var gps = new GpsTracking
            {
                TruckId = dto.TruckId,
                Location = dto.Location,
                Timestamp = DateTime.UtcNow
            };

            _repo.Add(gps);
        }
    }
}
