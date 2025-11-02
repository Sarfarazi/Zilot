using Microsoft.AspNetCore.Mvc;
using Zelut.Application.Services;

namespace Zelut.Api.Controllers
{
    public class SearchController : BaseController
    {
        private readonly IProductService _productService;
        public SearchController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("/search-products/{search}")]
        public async Task<IActionResult> SearchProduct([FromRoute] string search)
        {
            var result = await _productService.SearchProducts(search);
            return Ok(result);
        }
    }
}