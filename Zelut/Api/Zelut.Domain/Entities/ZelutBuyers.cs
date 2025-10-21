using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zelut.Domain.Entities;

public class ZelutBuyers : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public DateTime? UpdateDate { get; set; }
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
    public string InstallerTel { get; set; }
    public string? InstallerEmail { get; set; }
    public string GoodsName { get; set; }
    public int GoodsMetraj { get; set; }
    public int? GoodsCount { get; set; }
    public string GoodsSerial { get; set; }
    public string PictureFactor { get; set; }
    public string PictureSerial { get; set; }
    public string KindOfGoods { get; set; }
    public string? Description { get; set; }
    public string? CartNo { get; set; }
    public string? ShebaNo { get; set; }
    public string Ip { get; set; }
}