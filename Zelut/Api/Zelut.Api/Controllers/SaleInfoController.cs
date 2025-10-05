using Microsoft.AspNetCore.Mvc;
using Zelut.Domain.Entities;

public class SaleInfoController : BaseController
{
    private readonly ISaleInfoService _saleInfoService;
    public SaleInfoController(ISaleInfoService saleInfoService)
    {
        _saleInfoService = saleInfoService;
    }

    [HttpPost]
    [Route("sale-info/create")]
    public async Task<IActionResult> Create([FromBody]ZelutBuyerRequestDto request)
    {
        var result = await _saleInfoService.CretaeSaleInfo(request);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}