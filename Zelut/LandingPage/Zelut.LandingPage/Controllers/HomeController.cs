using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
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

        [HttpGet("Products/{category_id?}")]
        public async Task<IActionResult> Products(int? category_id = null)
        {
            var url = string.Format(AppConfig.RestApiConfig.ZelutUrls.GetProductsUrl, category_id.HasValue ? category_id : 0);
            var web_restApi_result = await _httpClient.RestApiGetAsync<ResultData<List<ZelutProductsWebResultDto>>>(url);

            if (!web_restApi_result.IsSuccess)
            {
                this.SetAlert(web_restApi_result.Message, "error");
            }

            return View(web_restApi_result.Data);
        }

        [HttpGet("Product/{id}/{detail_id}")]
        public async Task<IActionResult> Product(int id, int detail_id)
        {
            var web_restApi_reuslt = await _httpClient.RestApiGetAsync<ResultData<ZelutProductDetail>>(string.Format(AppConfig.RestApiConfig.ZelutUrls.GetProductDetilUrl, id, detail_id));

            if (!web_restApi_reuslt.IsSuccess)
            {
                this.SetAlert(web_restApi_reuslt.Message, "error");
            }

            return View(web_restApi_reuslt.Data);
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
                return View(request);
            }

            #region CheckSerialNumber
            var serial_numbers = request.GoodsSerial.Split('-').ToList();
            if (serial_numbers.Count != request.GoodsCount)
            {
                this.SetAlert("شماره سریال های وارد شده با تعداد مورد نظر هم خوانی ندارد.", "error");
                return View(request);
            }

            var count_serial_numbers_less_than_eight_characters = serial_numbers.Where(sn => sn.Length > 8 || sn.Length < 8).Count();
            if (count_serial_numbers_less_than_eight_characters > 0)
            {
                this.SetAlert("شماره سریال های وارد شده دقیقا باید 8 رقم باشند.", "error");
                return View(request);
            }

            var serial_numbers_no_repetitive = new HashSet<string>(serial_numbers);
            if (serial_numbers_no_repetitive.Count != serial_numbers.Count)
            {
                this.SetAlert("شماره سریال های وارد شده نباید تکراری باشند.", "error");
                return View(request);
            }

            #endregion

            #region UploadFile
            var uploadFactorResult = await _fileHelper.UploadAsync(request.PictureFactor);
            if (!uploadFactorResult.IsSuccess)
            {
                this.SetAlert(uploadFactorResult.Message!, "error");
                return View(request);
            }

            var uploadPictureResult = await _fileHelper.UploadAsync(request.PictureSerial);
            if (!uploadPictureResult.IsSuccess)
            {
                this.SetAlert(uploadPictureResult.Message!, "error");
                return View(request);
            }
            #endregion

            var rest_api_request = new RestApiSaleInofDto
            {
                PictureFactor = uploadFactorResult.Data,
                PictureSerial = uploadPictureResult.Data,
                BuyerEmail = request.BuyerEmail,
                BuyerFamily = request.BuyerFamily,
                BuyerName = request.BuyerName,
                BuyerTel = request.BuyerTel,
                GoodsCount = request.GoodsCount,
                GoodsMetraj = request.GoodsMetraj,
                GoodsName = request.GoodsName,
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
                Description = request.Description
            };

            // TODO : delete file uploaded from File upload folder
            var web_service_result = await _httpClient.RestApiPostAsync<RestApiSaleInofDto, Result>(AppConfig.RestApiConfig.ZelutUrls.CreateBuyerSellerUrl, rest_api_request);

            if (!web_service_result.IsSuccess)
            {
                this.SetAlert(web_service_result.Message, "error");
                return View(request);
            }

            this.SetAlert(web_service_result.Message, "success");
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

        [HttpPost()]
        public async Task<IActionResult> ContactUs(ZelutContactUsDto contactUs)
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

            var web_service_api_rest_result = await _httpClient.RestApiPostAsync<ZelutContactUsDto, Result>(AppConfig.RestApiConfig.ZelutUrls.ContactUs, contactUs);
            if (!web_service_api_rest_result.IsSuccess)
            {
                this.SetAlert(web_service_api_rest_result.Message, "error");
                return View();
            }

            this.SetAlert(web_service_api_rest_result.Message, "success");
            return View();
        }

        public IActionResult Weblog()
        {
            return View();
        }

        [HttpGet("article/{id}/{url_title}", Name ="article")]
        public async Task<IActionResult> Article(int id, string url_title)
        {
            var url = string.Format(AppConfig.RestApiConfig.ZelutUrls.GetBlogUrl, id);
            var web_service_api_result = await _httpClient.RestApiGetAsync<ResultData<BlogDto>>(url);
            if(!web_service_api_result.IsSuccess)
            {
                this.SetAlert(web_service_api_result.Message,"error");
                return View();
            }

            return View(web_service_api_result.Data);
        }

        public IActionResult Articles()
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

        public IActionResult CashBack()
        {
            return View();
        }

        //[HttpPost()]
        //public IActionResult CashBack()
        //{
        //    return View();
        //}
    }
}