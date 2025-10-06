using Zelut.Application.DTOs.Sms;
using Zelut.Application.Services;

namespace Zelut.Infrastructure.Services;

public class SmsService : ISmsService
{
    private readonly HttpClient _httpClient;
    public SmsService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("asanak-sms");
    }
    public Task<SmsAsanakResult> SendSms(string message, string phoneNumber)
    {
        throw new NotImplementedException();
    }
}
