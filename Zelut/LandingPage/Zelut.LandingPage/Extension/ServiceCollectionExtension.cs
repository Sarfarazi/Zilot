using Zelut.LandingPage.Helpers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient("zelut-api",client =>
        {
            client.BaseAddress = new Uri(AppConfig.RestApiConfig.BaseZelutApiAddress);
        });

        return services;
    }

    public static IServiceCollection RegisterApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IFileHelper, FileHelper>();
        return services;
    }
}