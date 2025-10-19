using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Zelut.Application.DTOs.Products;
using Zelut.Application.Services;

namespace Zelut.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IHostingEnvironment _environment;
    public ProductService(IHostingEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<ResultData<ZelutProductDetail>> GetProduct(int id, int detail_id)
    {
        var file_path = Path.Combine(_environment.WebRootPath, "Data", "products.json");
        if (!File.Exists(file_path))
        {
            return new ResultData<ZelutProductDetail>
            {
                IsSuccess = false,
                Message = "محصولی یافت نشد."
            };
        }

        var json_content = await File.ReadAllTextAsync(file_path);
        var products = JsonConvert.DeserializeObject<List<ZelutProductsDto>>(json_content);

        var product = products.FirstOrDefault(p => p.Id == id);
        var product_detail = product.ZelutDetail.FirstOrDefault(detail => detail.Id == detail_id);

        if(product == null || product_detail == null)
        {
            return new ResultData<ZelutProductDetail>
            {
                IsSuccess = false,
                Message = "محصولی با این مشخصات یافت نشد."
            };
        }

        ZelutProductDetail result = new()
        {
            Id = product.Id,
            NameCollection = product.NameCollection,
            NameModel = product.NameModel,
            ZelutDetail = product_detail
        };

        return new ResultData<ZelutProductDetail>
        {
            Data = result,
            IsSuccess = true,
            Message = string.Empty
        };
    }

    public async Task<ResultData<List<ZelutProductsDto>>> GetProducts(int category_id)
    {
        var file_path = Path.Combine(_environment.WebRootPath, "Data", "products.json");
        if (!File.Exists(file_path))
        {
            return new ResultData<List<ZelutProductsDto>>
            {
                IsSuccess = false,
                Message = "محصولی یافت نشد."
            };
        }

        var json_content = await File.ReadAllTextAsync(file_path);
        var result = JsonConvert.DeserializeObject<List<ZelutProductsDto>>(json_content);

        if(category_id != 0)
        {
            result = result!.Where(r => r.Id == category_id).ToList();
        }

        return new ResultData<List<ZelutProductsDto>>
        {
            IsSuccess = true,
            Data = result,
            Message = string.Empty
        };
    }

    public async Task<ResultData<List<ZelutProductsDto>>> SearchProducts(string search)
    {
        var file_path = Path.Combine(_environment.WebRootPath, "Data", "products.json");
        if (!File.Exists(file_path))
        {
            return new ResultData<List<ZelutProductsDto>>
            {
                IsSuccess = false,
                Message = "محصولی یافت نشد."
            };
        }

        var json_content = await File.ReadAllTextAsync(file_path);
        var products = JsonConvert.DeserializeObject<List<ZelutProductsDto>>(json_content);

        var result = products.Where(p => p.NameModel.StartsWith(search) || p.ZelutDetail.Any(detail => detail.NameJadid.Contains(search)))
            .Select(p => new ZelutProductsDto
            {
                Id = p.Id,
                NameCollection = p.NameCollection,
                NameModel = p.NameModel,
                Description = p.Description,
                EnglishName = p.EnglishName,
                ZelutDetail = p.ZelutDetail.Where(detail => detail.NameJadid.StartsWith(search)).ToList()
            }).ToList();

        return new ResultData<List<ZelutProductsDto>>
        {
            IsSuccess = true,
            Data= result,
            Message = string.Empty
        };
    }
}
