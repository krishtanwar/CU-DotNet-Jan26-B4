using Corporate_portal_01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Corporate_portal_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<Employee> _employees=new List<Employee>()
        
            {
                new Employee { EmployeeId = 1, EmployeeName = "Sarah Khan", EmployeePosition = "Project Manager", Salary = 85000 },
                new Employee { EmployeeId = 2, EmployeeName = "Upkaar Malik", EmployeePosition = "Software Engineer", Salary = 72000 },
                new Employee { EmployeeId = 3, EmployeeName = "Priya Sharma", EmployeePosition = "QA Engineer", Salary = 65000 },
                new Employee { EmployeeId = 4, EmployeeName = "Arjun Mehta", EmployeePosition = "UI/UX Designer", Salary = 68000 }
            };
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Announcement = "There will be a holiday on 21st March";
            ViewData["Department_Name"] = "Software Development";
            ViewData["Server_Status"] = true;
            return View(_employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
