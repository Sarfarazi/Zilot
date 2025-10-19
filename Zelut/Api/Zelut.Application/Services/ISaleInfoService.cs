using Zelut.Application.DTOs.ZelutBuyer;

public interface ISaleInfoService
{
    Task<Result> CretaeSaleInfo(ZelutBuyerRequestDto request);
    Task<ResultData<ZelutBuyerDto>> GetByPhoneNumber(string phoneNumber); 
}