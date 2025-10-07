using Microsoft.Extensions.Logging;
using Zelut.Application.DTOs.Sms;
using Zelut.Application.Services;

namespace Zelut.Infrastructure.Services;

public class SmsService : ISmsService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<SmsService> _logger;
    public SmsService(IHttpClientFactory httpClientFactory, ILogger<SmsService> logger)
    {
        _httpClient = httpClientFactory.CreateClient("asanak-sms");
        _logger = logger;
    }

    public async Task<ResultData<SmsAsanakResult>> SendSms(string message, string phoneNumber)
    {
        var smsAsanakRequest = new SmsAsanakRequest
        {
            username = ApplicationConfig.SmsUrls.Asanak.Username,
            password = ApplicationConfig.SmsUrls.Asanak.Password,
            source = ApplicationConfig.SmsUrls.Asanak.Source,
            destination = phoneNumber,
            message = message
        };

        var sms_restApi_result = await _httpClient.RestApiPostAsync<SmsAsanakRequest, SmsAsanakResult>(_httpClient.BaseAddress!.AbsolutePath, smsAsanakRequest);

        // TODO : handle error for sms service and log error
        if(sms_restApi_result?.meta.status != 0 && sms_restApi_result?.meta.status != 200)
        {
            return new ResultData<SmsAsanakResult>
            {
                IsSuccess = false,
                Data = sms_restApi_result!,
                Message = $"asanak sms service error => {sms_restApi_result?.meta.status} : {sms_restApi_result?.meta.message}"
            };
        }

        return new ResultData<SmsAsanakResult>
        {
            IsSuccess = true,
            Data = sms_restApi_result!,
            Message = $"sms send successfully."
        };
    }
}
