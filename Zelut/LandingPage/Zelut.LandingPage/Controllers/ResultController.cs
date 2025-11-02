using Microsoft.AspNetCore.Mvc;

namespace Zelut.LandingPage.Controllers
{
    public class ResultController : Controller
    {
        [HttpGet]
        public IActionResult Success(string? messgae = null)
        {
            ViewBag.Message = messgae;
            return View();
        }

        [HttpGet]
        public IActionResult Error(string? message = null)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}
