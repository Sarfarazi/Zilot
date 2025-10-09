namespace Zelut.LandingPage.DTOs;

public class ZelutProductsWebResultDto
{
    public string NameCollection { get; set; }
    public string NameModel { get; set; }
    public List<ZelutProductDetailDto> ZelutDetail { get; set; }
}

public class ZelutProductDetailDto
{
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
    public int ArzehRol { get; set; }
    public List<ZelutDetailColors> ZelutDetailColors { get; set; }
}

public class ZelutDetailColors
{
    public string Rang { get; set; }
    public string SharhKala { get; set; }
    public string KodePalaz { get; set; }
    public string ItemDesription { get; set; }
    public string GeijeMucket { get; set; }
    public double ErtefaKol { get; set; }
    public long VaznehKol { get; set; }
}
