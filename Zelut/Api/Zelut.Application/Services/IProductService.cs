using Zelut.Application.DTOs.Products;

namespace Zelut.Application.Services;

public interface    IProductService
{
   Task<ResultData<List<ZelutProductsDto>>> GetProducts();
}