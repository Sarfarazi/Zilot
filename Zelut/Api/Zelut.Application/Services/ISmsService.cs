using Zelut.Application.DTOs.Sms;
namespace Zelut.Application.Services;

public interface ISmsService
{
    Task<ResultData<SmsAsanakResult>> SendSms(string message, string phoneNumber);
}
