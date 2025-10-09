using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Zelut.LandingPage.DTOs;
using Zelut.LandingPage.Extension;

namespace Zelut.LandingPage.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("zelut-api");
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var web_restApi_result = await _httpClient.RestApiGetAsync<ResultData<List<ZelutProductsWebResultDto>>>(AppConfig.RestApiConfig.ZelutUrls.GetProductsUrl);
            
            if(!web_restApi_result.IsSuccess)
            {
                this.SetAlert(web_restApi_result.Message,"error");
            }

            return View(web_restApi_result.Data);
        }
    }
}
