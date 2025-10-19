using Microsoft.AspNetCore.Mvc;

public class SaleInfoController : BaseController
{
    private readonly ISaleInfoService _saleInfoService;
    public SaleInfoController(ISaleInfoService saleInfoService)
    {
        _saleInfoService = saleInfoService;
    }

    [HttpPost]
    [Route("sale-info/create")]
    public async Task<IActionResult> Create([FromBody] ZelutBuyerRequestDto request)
    {
        var result = await _saleInfoService.CretaeSaleInfo(request);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost]
    [Route("sale-info/add-card-info")]
    public async Task<IActionResult> AddCardInfo([FromBody] ZelutBuyerCardInfoDto request)
    {
        var buyer_info = await _saleInfoService.GetByPhoneNumber(request.PhoneNumber);
        return Ok();
    }
}

public class ZelutBuyerCardInfoDto
{
    public string CardNumber { get; set; }
    public string ShebaNumber { get; set; }
    public string PhoneNumber { get; set; }
}