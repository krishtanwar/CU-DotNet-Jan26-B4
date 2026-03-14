using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
using FinTrackPro.Models;

namespace FinTrackPro.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Assets> assets = new List<Assets>()
        {
            new Assets{Id=1,Name="Krish", Price=240, Quantity=2},
            new Assets{ Id=2, Name="Upkaar", Price=320, Quantity=3 },
            new Assets{ Id=3, Name="Harsh", Price=250, Quantity=4 }
        };

        public IActionResult Index()
        {
            double total = assets.Sum(a => a.TotalValue);

            ViewData["Total"] = total;

            return View(assets);
        }

        [Route("Asset/Info/{id:int}")]
        public IActionResult Details(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset == null)
                return NotFound();

            return View(asset);
        }

        public IActionResult Delete(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset != null)
            {
                assets.Remove(asset);

                TempData["Message"] = "Asset deleted successfully!";
            }

            return RedirectToAction("Index");
        }
    }
}
