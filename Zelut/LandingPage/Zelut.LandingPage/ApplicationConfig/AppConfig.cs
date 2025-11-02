using Microsoft.Extensions.Configuration;
using Zelut.LandingPage.ApplicationConfig;

public static class AppConfig
{
    public static RestApiConfig RestApiConfig { get; set; }
    public static SqlServerConfig SqlServerConfig { get; set; }
    public static FileUrlsConfig FileUrls { get; set; }
    public static void InitializeAppConfig(IConfiguration configuration)
    {
        RestApiConfig = configuration.GetSection("RestApi").Get<RestApiConfig>()!;
        SqlServerConfig = configuration.GetSection("SqlServer").Get<SqlServerConfig>()!;
        FileUrls = configuration.GetSection("FileUrls").Get<FileUrlsConfig>()!;
    }

    public static void InitializeProductionAppConfig(IConfiguration configuration)
    {
        RestApiConfig = configuration.GetSection("RestApiProduction").Get<RestApiConfig>()!;
        SqlServerConfig = configuration.GetSection("SqlServerProduction").Get<SqlServerConfig>()!;
        FileUrls = configuration.GetSection("FileUrls").Get<FileUrlsConfig>()!;
    }
}