public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient("zelut-api",client =>
        {
            client.BaseAddress = new Uri(AppConfig.RestApiConfig.BaseAddress);
        });

        return services;
    }
}