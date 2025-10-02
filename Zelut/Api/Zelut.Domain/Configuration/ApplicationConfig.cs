using Microsoft.Extensions.Configuration;

public class ApplicationConfig
{
    public static SqlServerConfig SqlServer { get; set; }
    public static void InitializeApplicationConfig(IConfiguration configuration)
    {
        SqlServer = configuration.GetSection("SqlServer").Get<SqlServerConfig>()!;
    }
}