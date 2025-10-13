using Zelut.Application.DTOs.Products;

namespace Zelut.Application.Services;

public interface IProductService
{
    Task<ResultData<ZelutProductDetail>> GetProduct(int id, int detail_id);
    Task<ResultData<List<ZelutProductsDto>>> GetProducts(int category_id);
}