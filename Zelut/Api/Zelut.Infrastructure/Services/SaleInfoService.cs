using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Zelut.Application.DTOs;
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


        //var smsResult = await _smsService.SendSms("پبام تستی", request.BuyerTel);
        return new Result
        {
            IsSuccess = true,
            Message = "عملیات ثبت اطلاعات با موفقیت ثبت شد."
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
