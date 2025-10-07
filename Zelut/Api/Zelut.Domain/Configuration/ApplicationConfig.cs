using Microsoft.Extensions.Configuration;
using Zelut.Domain.Configuration;

public class ApplicationConfig
{
    public static SqlServerConfig SqlServer { get; set; }
    public static SmsUrlsConfig SmsUrls { get; set; }
    public static void InitializeApplicationConfig(IConfiguration configuration)
    {
        SqlServer = configuration.GetSection("SqlServer").Get<SqlServerConfig>()!;
        SmsUrls = configuration.GetSection("SmsUrls").Get<SmsUrlsConfig>()!;
    }
}