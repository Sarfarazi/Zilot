using System.ComponentModel.DataAnnotations;

namespace Zelut.LandingPage.DTOs;

public class RestApiSaleInofDto
{
    public string BuyerName { get; set; }
    public string BuyerFamily { get; set; }
    public string BuyerTel { get; set; }
    public string? BuyerEmail { get; set; }
    public string SellerNameShop { get; set; }
    public string SellerName { get; set; }
    public string SellerTel { get; set; }
    public string? SellerEmail { get; set; }
    public string InstalerName { get; set; }
    public string InstalerFamily { get; set; }
    public string InstalerTel { get; set; }
    public string? InstallerEmail { get; set; }
    public string GoodsName { get; set; }
    public int GoodsMetraj { get; set; }
    public int GoodsCount { get; set; }
    public string GoodsSerial { get; set; }
    public string PictureFactor { get; set; }
    public string KindOfGoods { get; set; }
    public string? Description { get; set; }
}