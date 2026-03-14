using Microsoft.AspNetCore.Mvc;
using Assessment10.Models;

public class PortfolioController : Controller
{

    private static List<Asset> assets = new List<Asset>()
{
new Asset{ Id = 1, Name="Krish", Value = 2000},
new Asset{ Id = 2, Name="Upkaar", Value = 3000},
new Asset{ Id = 3, Name="harsh", Value = 4000}
};

    public IActionResult Index()
    {
        ViewData["Total"] = assets.Sum(a => a.Value);
        return View(assets);
    }

    [Route("Asset/Info/{id:int}")]
    public IActionResult Details(int id)
    {
        var asset = assets.FirstOrDefault(a => a.Id == id);
        return View(asset);
    }

    public IActionResult Delete(int id)
    {
        var asset = assets.FirstOrDefault(a => a.Id == id);

        if (asset != null)
        {
            assets.Remove(asset);
            TempData["Message"] = "Asset Deleted Successfully";
        }

        return RedirectToAction("Index");
    }

}