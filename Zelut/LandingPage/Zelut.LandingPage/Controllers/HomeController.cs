using Microsoft.AspNetCore.Mvc;

namespace Zelut.LandingPage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/products")]
        public IActionResult Products()
        {
            return View();
        }
        
        public IActionResult Product()
        {
            return View();
        }

        public IActionResult SalesInfo()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Weblog()
        {
            return View();
        }
    }
}