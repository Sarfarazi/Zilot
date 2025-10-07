public interface ISaleInfoService
{
    Task<Result> CretaeSaleInfo(ZelutBuyerRequestDto request);
}