using Zelut.Domain.Entities;
public interface ISaleInfoService
{
    Task<Result> CretaeSaleInfo(SaleCustomerInfoEntity saleCustomerInfo);
}