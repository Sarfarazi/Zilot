using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Zelut.Application.DTOs.ZelutBuyer;

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

    [HttpGet()]
    [Route("sale-info/get-by-id/{id}")]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var buyer_result = await _saleInfoService.GetById(id);
        if (!buyer_result.IsSuccess)
        {
            return BadRequest(buyer_result);
        }

        return Ok(buyer_result);
    }

    [HttpPost]
    [Route("sale-info/add-card-info")]
    public async Task<IActionResult> AddCardInfo([FromBody] ZelutBuyerCardInfoDto request)
    {
        var insert_buyer_card_info_result = await _saleInfoService.AddCardBuyerInfo(request);
        if (!insert_buyer_card_info_result.IsSuccess)
        {
            return BadRequest(insert_buyer_card_info_result);
        }

        return Ok(insert_buyer_card_info_result);
    }

    [HttpPost()]
    [Route("sale-info/get-zelut-buyers")]
    public async Task<IActionResult> GetZelutBuyers([FromBody]GetZelutBuyerRequestDto request)
    {
        var result = await _saleInfoService.GetAll(request);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}