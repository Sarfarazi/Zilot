namespace Zelut.Domain.Configuration;

public class SmsUrlsConfig
{
    public AsanakConfig Asanak { get; set; }
}

public class AsanakConfig
{
    public string Url { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Source { get; set; }
}