using Newtonsoft.Json;

namespace Zelut.LandingPage.DTOs;

public class ZelutProductsWebResultDto
{
    public int Id { get; set; }
    public string NameCollection { get; set; }
    public string NameModel { get; set; }
    public string Description { get; set; }
    public string EnglishName { get; set; }
    public List<ZelutProductDetailDto> ZelutDetail { get; set; }
}

public class ZelutProductDetailDto
{
    public int Id { get; set; }
    public string CodeDaste { get; set; }
    public string NameAvalieh { get; set; }
    public string NameJadid { get; set; }
    public string NameJadidEngelisi { get; set; }
    public string Sharh { get; set; }
    public string NoeBaft { get; set; }
    public string JensNakh { get; set; }
    public int TedadeRang { get; set; }
    public string Backing { get; set; }
    public int VaznehBacking { get; set; }
    public string RangeBacking { get; set; }
    public double ArzehRol { get; set; }
    public double ToleRol { get; set; }
    public List<ZelutDetailColors> ZelutDetailColors { get; set; }
}

public class ZelutDetailColors
{
    public string Rang { get; set; }
    public string SharhKala { get; set; }
    public string GeijeMucket { get; set; }
    public double ErtefaKol { get; set; }
    public int VaznehKol { get; set; }
    public string Hex { get; set; }
}