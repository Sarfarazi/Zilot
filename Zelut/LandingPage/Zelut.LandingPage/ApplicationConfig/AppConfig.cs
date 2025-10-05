public static class AppConfig
{
    public static RestApiConfig RestApiConfig { get; set; }
    public static void InitializeAppConfig(IConfiguration configuration)
    {
        RestApiConfig = configuration.GetSection("RestApi").Get<RestApiConfig>()!;
    }   
}