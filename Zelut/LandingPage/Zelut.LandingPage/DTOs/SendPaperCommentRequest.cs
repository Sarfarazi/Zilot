using System.ComponentModel.DataAnnotations;

namespace Zelut.LandingPage.DTOs;

public class SendPaperCommentRequest
{
    [Required(ErrorMessage = "توضیحات الزامی است")]
    [MaxLength(250, ErrorMessage = "حداکثر تعداد کاراکتر برای توضیحات 250 کاراکتر می باشد.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "نام الزامی است.")]
    [MaxLength(150, ErrorMessage = "حداکثر تعداد کاراکتر برای نام 150 کاراکتر می باشد")]
    public string Name { get; set; }

    [Required(ErrorMessage = "ایمیل الزامی است.")]
    
    public string Email { get; set; }
}
