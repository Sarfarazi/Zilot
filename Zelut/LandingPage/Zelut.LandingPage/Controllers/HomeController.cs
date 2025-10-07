using Microsoft.AspNetCore.Mvc;
using Zelut.LandingPage.Extension;

namespace Zelut.LandingPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("zelut-api");
        }

        public IActionResult Index()
        {
            return View();
        }

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

        [HttpPost()]
        public async Task<IActionResult> SalesInfo(CretaeSaleInfoDto request)
        {
            // var web_service_result = await _httpClient.RestApiPostAsync<CretaeSaleInfoDto, Result>(AppConfig.RestApiConfig.ZelutUrls.CreateBuyerSellerUrl, request);

            if (!web_service_result.IsSuccess)
            {
                this.SetAlert(web_service_result.Message, "error");
                return View();
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(ms => ms.Value.Errors.Count > 0)
                    .Select(ms => new
                    {
                        Messages = ms.Value.Errors.Select(e => e.ErrorMessage).ToList()
                    }).ToList();

                var errors_string = string.Join(',', errors);
                this.SetAlert(errors_string, "error");

                return View();
            }

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

        public IActionResult DesignConsulting()
        {
            return View();
        }

        public IActionResult InstallServices()
        {
            return View();
        }

        public IActionResult PriceList()
        {
            return View();
        }

        public IActionResult Success()
        {
            return PartialView();
        }

        public IActionResult Error()
        {
            return PartialView();
        }
    }
}