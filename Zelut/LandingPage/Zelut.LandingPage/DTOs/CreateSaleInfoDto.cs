using System.ComponentModel.DataAnnotations;

public class CreateSaleInfoDto
{
    [Required(ErrorMessage = "نام خریدار الزامی است.")]
    [MaxLength(50, ErrorMessage = "نام خریدار نمی‌تواند بیش از ۵۰ کاراکتر باشد.")]
    public string BuyerName { get; set; }

    [Required(ErrorMessage = "نام خانوادگی خریدار الزامی است.")]
    [MaxLength(50, ErrorMessage = "نام خانوادگی خریدار نمی‌تواند بیش از ۵۰ کاراکتر باشد.")]
    public string BuyerFamily { get; set; }

    [Required(ErrorMessage = "شماره تماس خریدار الزامی است.")]
    [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره تماس خریدار باید یک شماره موبایل معتبر باشد.")]
    public string BuyerTel { get; set; }

    public string? BuyerEmail { get; set; }

    [Required(ErrorMessage = "نام فروشگاه الزامی است.")]
    [MaxLength(100, ErrorMessage = "نام فروشگاه نمی‌تواند بیش از ۱۰۰ کاراکتر باشد.")]
    public string SellerNameShop { get; set; }

    [Required(ErrorMessage = "نام فروشنده الزامی است.")]
    [MaxLength(100, ErrorMessage = "نام فروشنده نمی‌تواند بیش از ۱۰۰ کاراکتر باشد.")]
    public string SellerName { get; set; }

    [Required(ErrorMessage = "شماره تماس فروشنده الزامی است.")]
    [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره تماس فروشنده باید یک شماره موبایل معتبر باشد.")]
    public string SellerTel { get; set; }

    public string? SellerEmail { get; set; }

    [Required(ErrorMessage = "نام نصاب الزامی است.")]
    [MaxLength(50, ErrorMessage = "نام نصاب نمی‌تواند بیش از ۵۰ کاراکتر باشد.")]
    public string InstalerName { get; set; }

    [Required(ErrorMessage = "نام خانوادگی نصاب الزامی است.")]
    [MaxLength(50, ErrorMessage = "نام خانوادگی نصاب نمی‌تواند بیش از ۵۰ کاراکتر باشد.")]
    public string InstalerFamily { get; set; }

    [Required(ErrorMessage = "شماره تماس نصاب الزامی است.")]
    [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره تماس نصاب باید یک شماره موبایل معتبر باشد.")]
    public string InstallerTel { get; set; }

    public string? InstallerEmail { get; set; }

    [Required(ErrorMessage = "نام کالا الزامی است.")]
    [MaxLength(50, ErrorMessage = "نام کالا نمی‌تواند بیش از ۵۰ کاراکتر باشد.")]
    public string GoodsName { get; set; }

    [Required(ErrorMessage = "متر مربع کالا الزامی است.")]
    public int GoodsMetraj { get; set; }

    [Required(ErrorMessage = "تعداد شماره سریال الزامی است.")]
    public int GoodsCount { get; set; }

    [Required(ErrorMessage = "شماره سریال الزامی است.")]
    public string GoodsSerial { get; set; }

    [Required(ErrorMessage = "فاکتور الزامی است.")]
    public IFormFile PictureFactor { get; set; }

    [Required(ErrorMessage = "کاربری کوکت الزامی است.")]
    public byte KindOfGoods { get; set; }
}