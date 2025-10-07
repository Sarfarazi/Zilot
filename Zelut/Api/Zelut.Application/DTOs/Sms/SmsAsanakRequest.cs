namespace Zelut.Application.DTOs.Sms;

public class SmsAsanakRequest
{
    public string username { get; set; }
    public string password { get; set; }
    public string source { get; set; }
    public string destination { get; set; }
    public string message { get; set; }
}
