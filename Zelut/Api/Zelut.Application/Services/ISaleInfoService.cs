using Zelut.Application.DTOs.ZelutBuyer;

public interface ISaleInfoService
{
    Task<Result> CretaeSaleInfo(ZelutBuyerRequestDto request);
    Task<Result> AddCardBuyerInfo(ZelutBuyerCardInfoDto buyerCardInfo);
    Task<ResultData<ZelutBuyerDto>> GetById(long id);
}