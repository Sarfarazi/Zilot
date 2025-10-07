namespace Zelut.Application.DTOs.Sms;

public class SmsAsanakResult
{
    public Meta meta { get; set; }
    public List<int> data { get; set; } = new List<int>();
}

public class Meta
{
    public int status { get; set; }
    public string message { get; set; }
}
