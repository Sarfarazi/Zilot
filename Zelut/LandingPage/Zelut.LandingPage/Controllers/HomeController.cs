using Microsoft.AspNetCore.Mvc;
using System.Runtime.ExceptionServices;
using Zelut.LandingPage.DTOs;
using Zelut.LandingPage.Extension;
using Zelut.LandingPage.Helpers;

namespace Zelut.LandingPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IFileHelper _fileHelper;
        public HomeController(IHttpClientFactory httpClientFactory, IFileHelper fileHelper)
        {
            _httpClient = httpClientFactory.CreateClient("zelut-api");
            _fileHelper = fileHelper;
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

            var uploadFactorResult = await _fileHelper.UploadAsync(request.PictureFactor);
            if(!uploadFactorResult.IsSuccess)
            {
                this.SetAlert(uploadFactorResult.Message!, "error");
                return View();
            }

            var rest_api_request = new RestApiSaleInofDto
            {
                PictureFactor = uploadFactorResult.Data,
                BuyerEmail = request.BuyerEmail,
                BuyerFamily = request.BuyerFamily,
                BuyerName = request.BuyerName,
                BuyerTel = request.BuyerTel,
                GoodsCount = request.GoodsCount,
                GoodsMetraj = request.GoodsMetraj,
                GoodsName =  request.GoodsName,
                GoodsSerial = request.GoodsSerial.Trim(),
                InstalerFamily = request.InstalerFamily,
                InstalerName = request.InstalerName,
                InstallerEmail = request.InstallerEmail,
                InstallerTel = request.InstallerTel,
                KindOfGoods = request.KindOfGoods,
                SellerEmail = request.SellerEmail,
                SellerName = request.SellerName,
                SellerNameShop = request.SellerNameShop,
                SellerTel = request.SellerTel,
            };

            var web_service_result = await _httpClient.RestApiPostAsync<RestApiSaleInofDto, Result>(AppConfig.RestApiConfig.ZelutUrls.CreateBuyerSellerUrl, rest_api_request);

            if (!web_service_result.IsSuccess)
            {
                this.SetAlert(web_service_result.Message, "error");
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