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
    [Route("/create")]
    public async Task<IActionResult> Create([FromBody]SaleCustomerInfoEntity saleCustomerInfo)
    {
        var result = await _saleInfoService.CretaeSaleInfo(saleCustomerInfo);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Message);
    }
}