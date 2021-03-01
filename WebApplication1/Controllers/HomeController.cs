using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public double TempBMI;
        public IActionResult Index()
        {
            return View();
        }
       
     
        public IActionResult DistanceConverter(DistanceConverter converter)
        {
            if (converter.FromDistance > 0)
            {
                converter.ConvertDistance();  
            }
            return View(converter);
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
                TempBMI = bmi.ReturnBMIImperial(bmi.Weight, bmi.Height);
                return RedirectToAction("HealthMessage", new { TempBMI });
            }
            else if(bmi.Units == "Metric")
            {
               TempBMI = bmi.ReturnBMIMetric(bmi.Weight, bmi.Height);
                return RedirectToAction("HealthMessage",new { TempBMI });
            }
            else
            {
                ViewBag.Error = "Error!";
                return View();
            }
        }
 
        public IActionResult HealthMessage(double TempBMI) 
        {
            return View(TempBMI);
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
