using Dapper;
using Microsoft.AspNetCore.Mvc;
using Zelut.Common.Helpers;
using Zelut.Common.Helpers.Dapper;
using Zelut.LandingPage.DTOs.API;

namespace Zelut.LandingPage.API.ZelutBuyer
{
    public class ZelutBuyerController : BaseController
    {
        private readonly IDapperHelper _dapperHelper;
        public ZelutBuyerController(IDapperHelper dapperHelper)
        {

        }

        [HttpGet()]
        [Route("zelut-buyers/get-all")]
        public async Task<IActionResult> GetZelutBuyersApi(GetZelutBuyerRequest request)
        {
            var result = await GetZelutBuyers(request);
            if(!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        #region Private
        private async Task<ResultData<List<GetZelutBuyerResponse>>> GetZelutBuyers(GetZelutBuyerRequest request)
        {
            try
            {
                var str_filter = string.Empty;
                var parameters = new DynamicParameters();

                if (!string.IsNullOrEmpty(request.Search))
                {
                    str_filter = @"WHERE 
                               (BuyerTel LIKE @search 
                                OR BuyerFamily LIKE @search 
                                OR InstallerTel LIKE @search 
                                OR InstalerName LIKE @search)";

                    parameters.Add("search", $"N%{request.Search}%");
                }

                var str_query = $@"SELECT
                                    BuyerName, BuyerFamily, BuyerTel, BuyerEmail,
                                    SellerNameShop, SellerName, SellerTel, SellerEmail,
                                    InstalerName, InstalerFamily, InstallerTel, InstallerEmail,
                                    GoodsName, GoodsMetraj, GoodsCount, GoodsSerial, KindOfGoods,
                                    Ip, CartNo, ShebaNo, Description
                                FROM ZelutBuyers z_buyer
                                {str_filter}
                                {PaginationHelper.GetSortWithPagingSqlCommand(request, "z_buyer")}";

                var result = await _dapperHelper.RunAsync<GetZelutBuyerResponse>(AppConfig.SqlServerConfig.CrmConnectionString, str_query, parameters);

                return new ResultData<List<GetZelutBuyerResponse>>
                {
                    IsSuccess = true,
                    Data = result.ToList(),
                    Message = string.Empty
                };
            }

            catch (Exception ex)
            {
                return new ResultData<List<GetZelutBuyerResponse>>
                {
                    IsSuccess = false,
                    Message = "خطایی پیش آمد، لطفا دوباره تلاش کنید."
                };
            }
        }
        #endregion
    }
}