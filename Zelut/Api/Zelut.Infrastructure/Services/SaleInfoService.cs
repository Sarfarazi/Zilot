using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using Zelut.Application.DTOs;
using Zelut.Application.DTOs.ZelutBuyer;
using Zelut.Application.Services;
using Zelut.Common.Helpers.Dapper;
using Zelut.Domain.Entities;
using Zelute.Application.Repository;

public class SaleInfoService : ISaleInfoService
{
    #region Field
    private readonly IRepository<Buyers> _saleCustomerInfoRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ISmsService _smsService;
    private readonly IDapperHelper _dapper;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public SaleInfoService(IRepository<Buyers> saleCustomerInfoRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IDapperHelper dapper, ISmsService smsService)
    {
        _mapper = mapper;
        _saleCustomerInfoRepository = saleCustomerInfoRepository;
        _httpContextAccessor = httpContextAccessor;
        _dapper = dapper;
        _smsService = smsService;
    }
    #endregion

    #region Methods
    public async Task<Result> CretaeSaleInfo(ZelutBuyerRequestDto request)
    {
        var checkSerialNumberExist = await CheckSerialNumberExist(request);
        if (checkSerialNumberExist.IsSuccess)
        {
            return new Result
            {
                IsSuccess = false,
                Message = checkSerialNumberExist.Message
            };
        }

        var zelutBuyer = _mapper.Map<Buyers>(request);
        var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        zelutBuyer.Ip = ip;
        await _saleCustomerInfoRepository.Add(zelutBuyer);
        var save_success_result = await _saleCustomerInfoRepository.SaveChangesAsync();
        if (!save_success_result.IsSuccess)
        {
            return new Result
            {
                IsSuccess = false,
                Message = save_success_result.Message
            };
        }

        #region SendSms
        var smsResult = await _smsService.SendSms($@"مشتری محترم، ضمن تشکر از انتخاب موکت زیلوت . لطفا جهت دریافت کمک هزینه نصب از طریق لینک ذیل اطلاعات کارت بانکی یا شماره شبای خود را ثبت کنید.
                                                    https://zelut.ir/cash-back/{zelutBuyer.Id}", request.BuyerTel);
        if (!smsResult.IsSuccess)
        {
            return new Result
            {
                IsSuccess = false,
                Message = "پیامک ثبت اطلاعات با موفقیت ارسال نشد."
            };
        }
        #endregion

        return new Result
        {
            IsSuccess = true,
            Message = "عملیات ثبت اطلاعات با موفقیت ثبت شد لطفا برای ادامه فرایند روی لینکی که برای شما پیامک شد کلیک کنید."
        };
    }
    public async Task<Result> AddCardBuyerInfo(ZelutBuyerCardInfoDto buyerCardInfo)
    {
        var buyer = await _saleCustomerInfoRepository.GetAsync(buyer => buyer.Id == buyerCardInfo.Id);
        if (buyer is null) return new Result { IsSuccess = false, Message = "خریداری با این اطلاعات وجود ندارد." };

        buyer.CartNo = buyerCardInfo.CartNumber;
        buyer.ShebaNo = buyerCardInfo.ShebaNumber;
        buyer.UpdateDate = DateTime.Now;
        var save_result = await _saleCustomerInfoRepository.SaveChangesAsync();

        if (!save_result.IsSuccess)
        {
            return new Result
            {
                IsSuccess = false,
                Message = save_result.Message
            };
        }

        return new Result
        {
            IsSuccess = true,
            Message = @"مشتری محترم اطلاعات حساب شما با موفقیت ثبت شد. کارشناسان ما پس از بررسی و تایید اطلاعات شما، مبلغ جایزه نقدی را به حساب شما واریز می نمایند."
        };
    }
    public async Task<ResultData<ZelutBuyerDto>> GetById(long id)
    {
        var zelut_buyer = await _saleCustomerInfoRepository
            .AsQueryable()
            .Where(zelutBuyer => zelutBuyer.Id == id)
            .Select(buyer => new ZelutBuyerDto
            {
                Id = buyer.Id,
                BuyerTel = buyer.BuyerTel,
                BuyerName = buyer.BuyerName,
                BuyerFamily = buyer.BuyerFamily,
                CartNo = buyer.CartNo,
                ShebaNo = buyer.ShebaNo,
                UpdateDate = buyer.UpdateDate
            }).FirstOrDefaultAsync();

        if (zelut_buyer.ShebaNo != null)
        {
            var message = @"مشتری محترم قبلا اطلاعات حساب شما برای این شماره فاکتور و سریال محصول به ثبت رسیده است .";
            return new ResultData<ZelutBuyerDto>
            {
                Message = message,
                IsSuccess = false
            };
        }

        if (zelut_buyer is null) return new ResultData<ZelutBuyerDto> { IsSuccess = false, Message = "خریداری با این شماره موبایل موجود نیست." };

        return new ResultData<ZelutBuyerDto>
        {
            IsSuccess = true,
            Data = zelut_buyer,
            Message = string.Empty
        };
    }
    #endregion

    #region Private
    private async Task<Result> CheckSerialNumberExist(ZelutBuyerRequestDto request)
    {
        var sql_query = @$"SELECT split.value AS serial_number
                           FROM Buyers AS buyer
                           CROSS APPLY string_split(buyer.GoodsSerial,'-') AS split";

        var serial_numbers_fromDB = await _dapper.RunAsync<ZelutSerailNumber>(ApplicationConfig.SqlServer.CrmConnectionString, sql_query);
        var serail_numbers_request = request.GoodsSerial.Split('-').ToList();

        var serial_number_exist = serail_numbers_request.FirstOrDefault(serial_number => serial_numbers_fromDB.Select(z => z.serial_number).Contains(serial_number));
        if (serial_number_exist is not null)
        {
            return new Result
            {
                IsSuccess = true,
                Message = $"شماره سریال {serial_number_exist} قبلا وارد شده"
            };
        }

        return new Result
        {
            IsSuccess = false,
            Message = string.Empty
        };
    }
    #endregion
}