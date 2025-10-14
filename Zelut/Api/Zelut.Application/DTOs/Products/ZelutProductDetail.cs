using Newtonsoft.Json;

namespace Zelut.Application.DTOs.Products;

public class ZelutProductDetail
{
    public int Id { get; set; }
    public string NameCollection { get; set; }
    public string NameModel { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    public string EnglishName { get; set; }
    public ZelutProductDetailDto? ZelutDetail { get; set; }
}