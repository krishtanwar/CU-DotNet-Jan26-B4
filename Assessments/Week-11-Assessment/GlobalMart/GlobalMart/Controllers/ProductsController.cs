using GlobalMart.Models;
using GlobalMart.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMart.Controllers
{
    public class ProductsController : Controller
    {
        private IPricingService _service {  get; set; }
        private List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Fan", BasePrice = 1200 },
            new Product { ProductId = 2, ProductName = "Cooler", BasePrice = 5000 },
            new Product { ProductId = 3, ProductName = "AC", BasePrice = 30000 }
        };
        private List<string> promoCodes = new List<string>
        {
            "NONE",
            "FREESHIP",
            "WINTER25"
        };

        public ProductsController(IPricingService service)
        {
            _service=service;
        }
        public IActionResult Index(int productId = 0, string selectedPromo = "NONE")
        {
            var result = products.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.BasePrice,
                SelectedPromo = (p.ProductId == productId) ? selectedPromo : "NONE",
                FinalPrice = (p.ProductId == productId)
                    ? _service.CalculatePrice(p.BasePrice, selectedPromo)
                    : p.BasePrice
            }).ToList();

            ViewBag.Products = result;
            ViewBag.PromoCodes = promoCodes;

            return View();
        }
    }
}
