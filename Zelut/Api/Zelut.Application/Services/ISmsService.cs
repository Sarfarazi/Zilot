using Zelut.Application.DTOs.Sms;
namespace Zelut.Application.Services;

public interface ISmsService
{
    Task<SmsAsanakResult> SendSms(string message, string phoneNumber);
}
