using GlobalMart.Services;
using Microsoft.AspNetCore.Mvc;
using GlobalMart.Models;

namespace GlobalMart.Controllers
{
    public class CartController : Controller
    {
        private IPricingService _service {  get; set; }
        Product product = new Product
        {
            ProductId = 1,
            ProductName = "Fan",
            BasePrice = 1200
        };
        public CartController(IPricingService service)
        {
            _service = service;
        }
        private List<string> promoCodes = new List<string>
        {
            "NONE",
            "FREESHIP",
            "WINTER25"
        };
        public IActionResult Index(string selectedPromo = "NONE")
        {
            ViewBag.BasePrice = product.BasePrice;
            ViewBag.FinalPrice = _service.CalculatePrice(product.BasePrice, selectedPromo);
            ViewBag.PromoCodes = promoCodes;
            ViewBag.SelectedPromo = selectedPromo;

            return View();
        }
    }
}
