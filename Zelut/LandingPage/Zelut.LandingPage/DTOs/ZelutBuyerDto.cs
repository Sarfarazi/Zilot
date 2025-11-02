using System.ComponentModel.DataAnnotations;

namespace Zelut.LandingPage.DTOs;

public class ZelutBuyerDto
{
    public string? BuyerName { get; set; }
    public string? BuyerFamily { get; set; }

    [Required(ErrorMessage = "وارد کردن شماره شبا الزامی است.")]
    [RegularExpression(@"^[0-9]{24}$", ErrorMessage = "شماره شبا باید فقط شامل 24 رقم عددی باشد.")]
    public string? ShebaNo { get; set; }

    [Required(ErrorMessage = "وارد کردن شماره کارت الزامی است.")]
    [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "شماره کارت باید فقط شامل 16 رقم عددی باشد.")]
    public string? CartNo { get; set; }
}