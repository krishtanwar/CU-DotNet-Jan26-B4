using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackingService.DTOs;
using TrackingService.Services;

namespace TrackingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingService _service;

        public TrackingController(ITrackingService service)
        {
            _service = service;
        }

        [HttpGet("gps")]
        [Authorize(Roles = "Manager")]
        public IActionResult Get()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpPost("gps")]
        [Authorize]
        public IActionResult Create(CreateGpsDto dto)
        {
            _service.Add(dto);
            return Ok("GPS Added");
        }
    }
}
