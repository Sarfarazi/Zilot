using Newtonsoft.Json;

namespace Zelut.LandingPage.DTOs;

public class ZelutProductDetail
{
    public int Id { get; set; }
    public string NameCollection { get; set; }
    public string NameModel { get; set; }
    public string Description { get; set; }
    public string EnglishName { get; set; }
    public ZelutProductDetailDto ZelutDetail { get; set; }
}