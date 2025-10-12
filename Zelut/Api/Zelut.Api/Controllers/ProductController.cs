using Microsoft.AspNetCore.Mvc;
using Zelut.Application.Services;

namespace Zelut.Api.Controllers;

public class ProductController : BaseController
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("product/get-products")]
    public async Task<IActionResult> GetProducts()
    {
        var result = await _productService.GetProducts();
        if(!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet("product/get-detail/{id}/{detail_id}")]
    public async Task<IActionResult> GetProductDetail([FromRoute]int id, [FromRoute]int detail_id)
    {
        var result = await _productService.GetProduct(id, detail_id);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}
