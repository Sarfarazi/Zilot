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
        public async Task<IActionResult> SalesInfo(CreateSaleInfoDto request)
        {
            // var web_service_result = await _httpClient.RestApiPostAsync<CretaeSaleInfoDto, Result>(AppConfig.RestApiConfig.ZelutUrls.CreateBuyerSellerUrl, request);

            //if (!web_service_result.IsSuccess)
            //{
            //    this.SetAlert(web_service_result.Message, "error");
            //    return View();
            //}

            if (!ModelState.IsValid)
            {
                var errorMessage = ModelState
                    .Where(ms => ms.Value.Errors.Count > 0)
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .FirstOrDefault();


                this.SetAlert(errorMessage!, "error");

                return View();
            }

            this.SetAlert("عملیات ثبت اطلاعات با موفقیت ثبت شد.", "success");
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

           public IActionResult Article()
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