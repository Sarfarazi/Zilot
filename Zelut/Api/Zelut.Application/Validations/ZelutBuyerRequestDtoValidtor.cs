using FluentValidation;

namespace Zelut.Application.Validations;

public class ZelutBuyerRequestDtoValidtor : AbstractValidator<ZelutBuyerRequestDto>
{
    public ZelutBuyerRequestDtoValidtor()
    {
        RuleFor(x => x.BuyerName)
            .NotEmpty().WithMessage("نام خریدار الزامی است")
            .MaximumLength(50).WithMessage("نام خریدار حداکثر باید 50 کاراکتر باشد");

        RuleFor(x => x.BuyerFamily)
            .NotEmpty().WithMessage("نام خانوادگی خریدار الزامی است")
            .MaximumLength(50).WithMessage("نام خانوادگی خریدار حداکثر باید 50 کاراکتر باشد");

        RuleFor(x => x.BuyerTel)
            .NotEmpty().WithMessage("شماره تماس خریدار الزامی است")
            .Matches(@"^09\d{9}$").WithMessage("شماره تماس خریدار وارد شده معتبر نیست.");

        RuleFor(x => x.SellerNameShop)
            .NotEmpty().WithMessage("نام فروشگاه الزامی است")
            .MaximumLength(100).WithMessage("نام فروشگاه حداکثر باید 100 کاراکتر باشد");

        RuleFor(x => x.SellerName)
            .NotEmpty().WithMessage("نام خانوادگی فروشنده الزامی است")
            .MaximumLength(50).WithMessage("نام خانوادگی فرشنده حداکثر باید 50 کاراکتر باشد");

        RuleFor(x => x.SellerTel)
            .NotEmpty().WithMessage("شماره همراه فروشنده الزامی است")
            .Matches(@"^09\d{9}$").WithMessage("شماره همراه فروشنده وارد شده معتبر نیست.");

        RuleFor(x => x.InstalerName)
            .NotEmpty().WithMessage("نام خانوادگی کارشناس نصب الزامی است")
            .MaximumLength(50).WithMessage("نام خانوادگی کارشناس نصب حداکثر باید 50 کاراکتر باشد");

        RuleFor(x => x.InstalerFamily)
            .NotEmpty().WithMessage("نام کارشناس نصب الزامی است")
            .MaximumLength(50).WithMessage("نام کارشناس نصب حداکثر باید 50 کاراکتر باشد");

        RuleFor(x => x.InstallerTel)
            .NotEmpty().WithMessage("شماره همراه کارشناس نصب الزامی است")
            .Matches(@"^09\d{9}$").WithMessage("شماره همراه کارشناس نصب وارد شده معتبر نیست.");

        RuleFor(x => x.GoodsName)
            .NotEmpty().WithMessage("نام موکت الزامی است")
            .MaximumLength(50).WithMessage("نام موکت حداکثر باید 50 کاراکتر باشد");

        RuleFor(x => x.GoodsMetraj)
            .NotEmpty().WithMessage("متراژ موکت الزامی است");

        RuleFor(x => x.KindOfGoods)
            .NotEmpty()
            .WithMessage("کاربری موکت الزامی است");
    }
}