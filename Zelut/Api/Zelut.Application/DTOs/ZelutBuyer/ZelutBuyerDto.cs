namespace Zelut.Application.DTOs.ZelutBuyer;

public class ZelutBuyerDto
{
    public long Id { get; set; }
    public string BuyerName { get; set; }
    public string BuyerFamily { get; set; }
    public string BuyerTel { get; set; }
    public string? ShebaNo { get; set; }
    public string? CartNo { get; set; }
    public DateTime? UpdateDate { get; set; }
}
