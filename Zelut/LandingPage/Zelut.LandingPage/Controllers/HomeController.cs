using Microsoft.AspNetCore.Mvc;

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
            var web_service_result = await _httpClient.RestApiPostAsync<CretaeSaleInfoDto, Result>(AppConfig.RestApiConfig.ZelutUrls.CreateBuyerSellerUrl, request);

            if(!web_service_result.IsSuccess)
            {
                return RedirectToAction("Error", "Result", (web_service_result is not null) ? web_service_result.Message : string.Empty);
            }

            if(!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(ms => ms.Value.Errors.Count > 0)
                    .Select(ms => new
                    {
                        Messages = ms.Value.Errors.Select(e => e.ErrorMessage).ToList()
                    }).ToList();

                var errors_string = string.Join(',', errors);

                return RedirectToAction("Error","Result", errors_string);
            }

            return RedirectToAction("Success","Result",(web_service_result is not null) ? web_service_result.Message : string.Empty);
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