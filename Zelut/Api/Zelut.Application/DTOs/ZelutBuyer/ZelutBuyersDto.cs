namespace Zelut.Application.DTOs.ZelutBuyer;

public class ZelutBuyersDto
{
    public string BuyerName { get; set; }
    public string BuyerFamily { get; set; }
    public string BuyerTel { get; set; }
    public string BuyerEmail { get; set; }

    public string SellerNameShop { get; set; }
    public string SellerName { get; set; }
    public string SellerTel { get; set; }
    public string SellerEmail { get; set; }

    public string InstalerName { get; set; }
    public string InstalerFamily { get; set; }
    public string InstalerTel { get; set; }
    public string InstalerEmail { get; set; }

    public string GoodsName { get; set; }
    public decimal? GoodsMetraj { get; set; }   // ممکنه عدد اعشاری باشه
    public int? GoodsCount { get; set; }        // ممکنه عدد صحیح باشه
    public string GoodsSerial { get; set; }
    public string KindOfGoods { get; set; }

    public string Ip { get; set; }
    public string CartNo { get; set; }
    public string ShebaNo { get; set; }
    public string Description { get; set; }
    public string PictureFactor { get; set; }
    public string PictureFactorUrl 
    {
        get
        {
            var url = string.Format(ApplicationConfig.FileUrls.GetFileUrl, PictureFactor);
            return url;
        }
    }
}