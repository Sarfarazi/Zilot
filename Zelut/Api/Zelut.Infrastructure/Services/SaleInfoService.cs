using Zelut.Domain.Entities;
using Zelute.Application.Repository;

public class SaleInfoService : ISaleInfoService
{
    private readonly IRepository<SaleCustomerInfoEntity> _saleCustomerInfoRepository;
    public SaleInfoService(IRepository<SaleCustomerInfoEntity> saleCustomerInfoRepository)
    {
        _saleCustomerInfoRepository = saleCustomerInfoRepository;
    }

    public async Task<Result> CretaeSaleInfo(SaleCustomerInfoEntity saleCustomerInfo)
    {
        await _saleCustomerInfoRepository.Add(saleCustomerInfo);
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