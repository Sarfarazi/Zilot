using AutoMapper;
using Microsoft.AspNetCore.Http;
using Zelut.Domain.Entities;
using Zelute.Application.Repository;

public class SaleInfoService : ISaleInfoService
{
    #region Field
    private readonly IRepository<ZelutBuyers> _saleCustomerInfoRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public SaleInfoService(IRepository<ZelutBuyers> saleCustomerInfoRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _saleCustomerInfoRepository = saleCustomerInfoRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    #endregion

    #region Methods
    public async Task<Result> CretaeSaleInfo(ZelutBuyerRequestDto request)
    {
        var zelutBuyer = _mapper.Map<ZelutBuyers>(request);
        var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        zelutBuyer.Ip = ip;
        await _saleCustomerInfoRepository.Add(zelutBuyer);
        var save_success_result = await _saleCustomerInfoRepository.SaveChangesAsync();
        if (!save_success_result)
        {
            return new Result
            {
                IsSuccess = false,
                Message = "data not save successfully, please try again."
            };
        }

        return new Result
        {
            IsSuccess = true,
            Message = "data successfully saved."
        };
    }
    #endregion
}