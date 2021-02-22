using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ConsoleAppProject.App02;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DistanceConverter()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BMI()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BMI(BMI bmi)
        {
            bmi.ReturnBMIImperial(bmi.Weight,bmi.Height);
            return View();
        }

        public IActionResult HealthMessage(double bmi)
        {
            return View(bmi);
        }
        public IActionResult StudentMarks()
        {
            return View();
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
