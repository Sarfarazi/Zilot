using Zelut.Common.Helpers.Dapper;
using Zelut.Common.Helpers.File;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient("zelut-api", client =>
        {
            client.BaseAddress = new Uri(AppConfig.RestApiConfig.BaseZelutApiAddress);
        });

        services.AddHttpClient("file-service", client =>
        {
            client.BaseAddress = new Uri(AppConfig.FileUrls.BaseUrl);
        });

        return services;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IFileHelper, FileHelper>();
        return services;
    }
}