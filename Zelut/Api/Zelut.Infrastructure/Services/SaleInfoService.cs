using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using Zelut.Application.DTOs;
using Zelut.Application.DTOs.ZelutBuyer;
using Zelut.Application.Services;
using Zelut.Common.Helpers;
using Zelut.Domain.Entities;
using Zelute.Application.Repository;

public class SaleInfoService : ISaleInfoService
{
    #region Field
    private readonly IRepository<ZelutBuyers> _saleCustomerInfoRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ISmsService _smsService;
    private readonly IDapperHelper _dapper;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public SaleInfoService(IRepository<ZelutBuyers> saleCustomerInfoRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IDapperHelper dapper, ISmsService smsService)
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

        var zelutBuyer = _mapper.Map<ZelutBuyers>(request);
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
                                                    https://zelut.ir/CashBack/{zelutBuyer.Id}", request.BuyerTel);
        if(!smsResult.IsSuccess)
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
        var buyer_result = await GetById(buyerCardInfo.Id);
        var buyer = buyer_result.Data;
        if (buyer is null) return new Result { IsSuccess = false, Message = buyer_result.Message };

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
            Message = "اطلاعات کارت شما با موفقیت ثبت شد."
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
                           FROM ZelutBuyers AS z_buyer
                           CROSS APPLY string_split(z_buyer.GoodsSerial,'-') AS split";

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