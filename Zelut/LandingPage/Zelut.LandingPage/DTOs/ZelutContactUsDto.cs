using System.ComponentModel.DataAnnotations;

namespace Zelut.LandingPage.DTOs;

public class ZelutContactUsDto
{
    [Required(ErrorMessage = "نام اجباری است.")]
    [MaxLength(50, ErrorMessage = "نام نمی تواند بیشتر از 50 کاراکتر باشد")]
    public string Name { get; set; }

    [Required(ErrorMessage = "نام خانوادگی اجباری است.")]
    [MaxLength(50, ErrorMessage = "نام خانوادگی نمی تواند بیشتر از 50 کاراکتر باشد.")]
    public string Family { get; set; }

    [Required(ErrorMessage = "شماره تماس اجباری است.")]
    [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره تماس نصاب باید یک شماره موبایل معتبر باشد.")]
    public string Mobile { get; set; }

    [MaxLength(100, ErrorMessage = "ایمیل نمیتواند ببیشتر از 100 کاراکتر باشد.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "ایمیل وارد شده معتبر نیست")]
    public string? Email { get; set; }

    [MaxLength(250, ErrorMessage = "حداکثر طول پیام باید 250 کاراکتر باشد.")]
    public string Message { get; set; }
}
