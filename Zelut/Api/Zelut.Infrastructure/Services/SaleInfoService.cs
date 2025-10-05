using AutoMapper;
using Zelut.Domain.Entities;
using Zelute.Application.Repository;

public class SaleInfoService : ISaleInfoService
{
    private readonly IRepository<ZelutBuyers> _saleCustomerInfoRepository;
    private readonly IMapper _mapper;
    public SaleInfoService(IRepository<ZelutBuyers> saleCustomerInfoRepository, IMapper mapper)
    {
        _mapper = mapper;
        _saleCustomerInfoRepository = saleCustomerInfoRepository;
    }

    public async Task<Result> CretaeSaleInfo(ZelutBuyerRequestDto request)
    {
        var zelutBuyer = _mapper.Map<ZelutBuyers>(request);
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
}