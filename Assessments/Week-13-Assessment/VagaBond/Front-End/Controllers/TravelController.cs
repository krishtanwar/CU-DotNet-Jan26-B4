using Front_End.Services;
using Microsoft.AspNetCore.Mvc;

namespace Front_End.Controllers
{
    public class TravelController : Controller
    {
        private readonly IDestinationService _service;

        public TravelController(IDestinationService service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index() {
            var data = await _service.GetAllAsync();
            return View(data);
        
        }
    }
}
