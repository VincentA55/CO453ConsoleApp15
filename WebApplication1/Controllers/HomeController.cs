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
        public IActionResult BMI(BMICalculator bmi)
        {
            if (bmi.Units == "Imperial")
            {
               
                return RedirectToAction("HealthMessage",  bmi.ReturnBMIImperial(bmi.Weight, bmi.Height));
            }
            else if(bmi.Units == "Metric")
            {
                bmi.ReturnBMIMetric(bmi.Weight, bmi.Height);
                return RedirectToAction("HealthMessage",  bmi.Bmi );
            }

            else
            {
                ViewBag.Error = "Error!";
                return View();
            }

           
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
